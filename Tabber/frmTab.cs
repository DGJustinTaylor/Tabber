using System;
using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

/*
    Programmer: Justin Taylor
    Date: 5/28/2019
    Date-Last-Edited: 6/27/2019

    NOTE: All functions, EventHandlers and any other methods 
    created before 7/1/2019 were created by Justin taylor.      
*/

namespace Tabber
{
    /*
        Target: ProcessData - Struct
        Purpose: Handle the storage of all important and necessary data
        used by the swapping system. Includes variables, constructor, and
        several 'get' functions for strings.
        Date: 5/29/2019
        Date-Last-Edited: 6/11/2019
    */
    public struct ProcessData
    {
        public int freq;
        public string id, winTitle;
        public IntPtr handle;
        public bool restart;

        public ProcessData(string p0, int p1, string p2, IntPtr p3, bool p4)
        {
            id = p0;
            freq = p1;
            winTitle = p2;
            handle = p3;
            restart = p4;
        }

        public string PID
        {
            get
            {
                return id;
            }
        }
        public string Title
        {
            get
            {
                return winTitle;
            }
        }
    }

    public partial class frmTab : Form
    {
        //The following variables are used for window swapping and window handles.
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        protected static extern int GetWindowTextLength(IntPtr hWnd);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        protected static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        protected static extern bool IsWindowVisible(IntPtr hWnd);
        [System.Runtime.InteropServices.DllImport("User32.dll", SetLastError = true)]
        static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
        protected delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        //This variable is for changing the window size and position.
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        //Several global variables that may or may not be necessary
        public ArrayList hiddenData = new ArrayList(); //Used to store data that is used across the whole program. 
        private Screen myScreen = null;
        public static ProcessData processDataToEdit; //Used in the second form for editing frequency.
        private Timer timerSwap;
        private Timer timerClick;
        frmChyron frmThree = new frmChyron();
        private bool isSwapping = false;
        private bool chyronActive = false;

        public frmTab()
        {
            InitializeComponent();
        }

        /*
        Target: frmTab_Load - EventHandler
        Purpose: Initializes the drop down list and
        initialized the timer for later use.
        Date: 5/28/2019
        Date-Last-Edited: 6/4/2019
    */
        private void frmTab_Load(object sender, EventArgs e)
        {
            RefreshProcesses();
            timerSwap = new Timer();
            timerSwap.Interval = 60000;
            timerSwap.Tick += new EventHandler(TimerSwapElapsed);

            timerClick = new Timer();
            timerClick.Interval = 60000;
            timerClick.Tick += new EventHandler(TimerClickElapsed);
            timerClick.Start();
        }

        private void btnEditFreq_Click(object sender, EventArgs e)
        {
            EditFrequency();
        }

        private void btnAddQueue_Click(object sender, EventArgs e)
        {
            AddQueue();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            BrowseFolder();
        }

        private void btnRemoveQueue_Click(object sender, EventArgs e)
        {
            RemoveQueue();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshProcesses();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopProcess();
        }

        private void btnSwapper_Click(object sender, EventArgs e)
        {
            SwapControl();
        }

        private void chkChyron_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChyron.Checked)
            {
                this.Height += 160;
            }
            else
            {
                this.Height -= 160;
            }
        }

        private void btnSentences_Click(object sender, EventArgs e)
        {
            if(lstQueue.Items.Count > 0)
            {
                ChyronTextControl();
                ChyronControl();
            }
            else
            {
                MessageBox.Show("There is nothing in the list", "User Error");
            }
        } 

        /* 
        Target: ChyronTextControl - Function
        Purpose: Used for passing text to the chyron and
        opening the chyron
        Date: 6/26/2019
        Date-Last-Edited: 6/27/2019
        */
        private void ChyronTextControl()
        {
            if (!chyronActive)
            {
                if (txtSentenceOne.Text != "")
                {
                    frmThree.texts.Add(txtSentenceOne.Text);
                }

                if (txtSentenceTwo.Text != "")
                {
                    frmThree.texts.Add(txtSentenceTwo.Text);
                }

                if (txtSentenceThree.Text != "")
                {
                    frmThree.texts.Add(txtSentenceThree.Text);
                }

                if (txtSentenceOne.Text == "" && txtSentenceTwo.Text == "" && txtSentenceThree.Text == "")
                {
                    MessageBox.Show("No text entered to show", "Input error");
                }
                else
                {
                    btnSentences.Text = "Stop Chyron";
                    chkChyron.Enabled = false;
                    frmThree.Show();
                    this.Focus();
                    frmThree.Activate();
                    this.Focus();
                    //The reason I do this is because without the double focus and the activate, 
                    //the first time the chyron is loaded it will hang without these.

                    chyronActive = true;
                }
            }
            else
            {
                btnSentences.Text = "Start Chyron";
                chkChyron.Enabled = true;

                frmThree.texts.Clear();
                frmThree.timerTextScroll.Stop();
                frmThree.Hide();
                chyronActive = false;
            }
        }

        private void TimerClickElapsed(object sender, EventArgs e)
        {
            timerClick.Stop();

            IntPtr handle = IntPtr.Zero;
            const uint WM_KEYDOWN = 0x0100;
            const int VK_RETURN = 0x0D;
            const int SW_SHOWNORMAL = 1;
            const int SW_HIDE = 0;
            const short SWP_NOMOVE = 0X0002;
            string tempStr = "";

            if (lstQueue.Items.Count > 0)
            {
                tempStr = lstQueue.SelectedItem.ToString().Substring(lstQueue.SelectedItem.ToString().IndexOf('-') + 2);

            }

            for (int i = 0; i < hiddenData.Count; i++)
            {
                if(((ProcessData)hiddenData[i]).winTitle.ToLower() == "pluto tv" && tempStr.ToLower() != "pluto tv")
                {
                    handle = ((ProcessData)hiddenData[i]).handle;

                    ShowWindowAsync(handle, SW_SHOWNORMAL);
                    SetWindowPos(handle, 0, 0, 0, 5, 5, SWP_NOMOVE);

                    Cursor.Current = Cursors.WaitCursor;
                    System.Threading.Thread.Sleep(500);
                    Cursor.Current = Cursors.Default;

                    ShowWindowAsync(handle, SW_HIDE);

                    break;
                }
            }

            timerClick.Start();

            return; 
        }

        /*
        Target: TimerSwapElapsed - EventHandler
        Purpose: Handle the starting and stopping of the timer,
        while also iterating through the queue.
        Date: 6/3/2019
        Date-Last-Edited: 6/5/2019
        */
        private void TimerSwapElapsed(object sender, EventArgs e)
        {
            timerSwap.Stop();

            if(lstQueue.SelectedIndex == lstQueue.Items.Count - 1)
            {
                lstQueue.SelectedIndex = 0;
            }
            else
            {
                lstQueue.SelectedIndex += 1;
            }

            SwapApp();

            timerSwap.Start();

            return;
        }

        /*
        Target: SwapControl - Function
        Purpose: Handle the starting and stopping of the entire
        swapping process. This is called on btnSwapper click.
        Date: 6/3/2019
        Date-Last-Edited: 6/5/2019
        */
        private void SwapControl()
        {
            if (lstQueue.Items.Count == 0)
            {
                MessageBox.Show("There is nothing in the queue. Aborting!", "Apps Missing");
            }
            else
            {
                if (isSwapping)
                {
                    btnSwapper.Text = "Start Swapping";
                    isSwapping = false;
                    timerSwap.Stop();
                }
                else
                {
                    btnSwapper.Text = "Stop Swapping";
                    isSwapping = true;
                    lstQueue.SelectedIndex = 0;
                    SwapApp();
                    timerSwap.Start();
                }
            }
        }

        /*
        Target: EditFrequency - Function
        Purpose: Handle the popup for the second form. The second form
        is where the user inputs the new frequency. The frequency that
        the user enters on the second form is then pulled in this function
        and saved into the hiddenData() ArrayList. This is called on btnEditFreq click.
        Date: 6/3/2019
        Date-Last-Edited: 6/13/2019
        */
        private void EditFrequency()
        {

            if(lstQueue.SelectedIndex >= 0)
            {
                try
                {
                    string tempStr = lstQueue.SelectedItem.ToString().Substring(lstQueue.SelectedItem.ToString().IndexOf('-') + 2);
                    // the above line may be confusing, but since I need the string name of the application
                    // but I append the time to the beginning, all this does is parse that part out.

                    for (int i = 0; i < hiddenData.Count; i++)
                    {
                        if (tempStr == ((ProcessData)hiddenData[i]).winTitle)
                        {
                            processDataToEdit = (ProcessData)hiddenData[i];
                        }
                    }

                    frmEditFreq frmTwo = new frmEditFreq();
                    frmTwo.ShowDialog();

                    if (frmTwo.secondsFreq > 0)
                    {
                        for (int i = 0; i < hiddenData.Count; i++)
                        {
                            if (((ProcessData)hiddenData[i]).handle == processDataToEdit.handle)
                            {
                                //create a new ProcessData item that will be stored over the previous item
                                //but with the same values other than the new frequency
                                ProcessData temp = (ProcessData)hiddenData[i];
                                int indexFreq = temp.freq;

                                temp.freq = frmTwo.secondsFreq * 60000;
                                hiddenData.RemoveAt(i);
                                hiddenData.Insert(i, temp);

                                int index = lstQueue.Items.IndexOf(indexFreq / 60000 + "min" + " - " + ((ProcessData)hiddenData[i]).winTitle);
                                lstQueue.Items.Remove(indexFreq / 60000 + "min" + " - " + ((ProcessData)hiddenData[i]).winTitle);
                                //We need to remove the old instance of the link from the list to be readded.

                                lstQueue.Items.Insert(index, ((ProcessData)hiddenData[i]).freq / 60000 + "min" + " - " + ((ProcessData)hiddenData[i]).winTitle);
                                lstQueue.SelectedItem = (((ProcessData)hiddenData[i]).freq / 60000 + "min" + " - " + ((ProcessData)hiddenData[i]).winTitle);
                                //Re-add the item to the queue then reselect it.
                                //This method has been known to mess up some.

                                RefreshDropDown();
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please Select an item from the queue", "Selection Error");
            }
               
        }

        /*
        Target: StopProcess - Function
        Purpose: Handle the stopping of the user selected window.
        This is done through the window handle rather than the process.
        This used to be done using the process, thus the name.
        This is called on btnStop click.
        Date: 6/3/2019
        Date-Last-Edited: 6/13/2019
        */
        private void StopProcess()
        {
            IntPtr processToStop = IntPtr.Zero;
            const int WM_CLOSE = 0x0010;

            try
            {
                for (int i = 0; i < hiddenData.Count; i++)
                {
                    if (((ProcessData)hiddenData[i]).handle == ((ProcessData)cmbProcesses.SelectedItem).handle)
                    {
                        processToStop = ((ProcessData)hiddenData[i]).handle;
                        break;
                    }
                }

                if (processToStop != null)
                {
                    SendMessage(processToStop, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                    //Sends the stop code to the selected window closing the individual window
                    //instead of the entire process.
                }

                else
                {
                    MessageBox.Show("That application is not running. Aborting!", "Invalid Request");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Cursor.Current = Cursors.WaitCursor;
            System.Threading.Thread.Sleep(500);
            Cursor.Current = Cursors.Default;

            RefreshProcesses();
        }

        /*
        Target: RefreshProcesses - Function
        Purpose: This pulls the processes currently open
        on the computer, but only the currently open process
        with visible windows. This is called on btnRefresh click and
        called whenever a function makes a change to the list such as
        the Stop function.
        Date: 5/28/2019
        Date-Last-Edited: 6/12/2019
        */
        private void RefreshProcesses()
        {
            hiddenData.Clear();

            EnumWindows(new EnumWindowsProc(EnumTheWindows), IntPtr.Zero);
            //Kind of like a recursive function, but not exactly what it is
            //This will find every instance of open windows and will store their information
            //inside our hidden data array.

            RefreshDropDown();
        }

        /*
        Target: EnumTheWindows - Function
        Purpose: Handles the window enumeration. This will find all 
        windows with selectable handles. This is used in the 
        RefreshProcesses function.
        Date: 6/11/2019
        Date-Last-Edited: 6/12/2019
        */
        private bool EnumTheWindows(IntPtr hWnd, IntPtr lParam)
        {
            int size = GetWindowTextLength(hWnd);

            if (size++ > 0 && IsWindowVisible(hWnd))
            {
                StringBuilder sb = new StringBuilder(size);
                GetWindowText(hWnd, sb, size);
                int processID = 0;
                int threadID = GetWindowThreadProcessId(hWnd, out processID);
                
                if(sb.ToString() != "Tabber")
                {
                    hiddenData.Add(new ProcessData(processID.ToString(), 60000, sb.ToString(), hWnd, false)); 
                    //grab all the data from our variables and store it all to our array in a new ProcessData object.
                }  
            }
            
            return true;
        }

        /*
        Target: RefreshDropDown - Function
        Purpose: Handle the refreshing of the drop down
        list by changing the data source and then sleeping
        the thread. This is called whenever a change has 
        been made to the drop down itself.
        Date: 6/5/2019
        Date-Last-Edited: 6/10/2019
        */
        private void RefreshDropDown()
        {
            cmbProcesses.DataSource = null;
            cmbProcesses.Items.Clear();
            //we just clear the drop down lists data source
            //then re-add it instead of using a loop to add and
            //delete items.
            //this is more effecient.

            cmbProcesses.DataSource = hiddenData;
            cmbProcesses.DisplayMember = "Title";
            cmbProcesses.ValueMember = "PID";

            Cursor.Current = Cursors.WaitCursor;
            System.Threading.Thread.Sleep(1000);
            Cursor.Current = Cursors.Default;

            cmbProcesses.SelectedIndex = 0;
        }

        /*
        Target: RefreshQueue - Function
        Purpose: Handles the refreshing of lstQueue.
        This is done by clearing it then re-adding all objects,
        except for whatever object may have changed or been removed.
        This is mostly used for if the frequency has been changed.
        Date: 6/11/2019
        Date-Last-Edited: 6/12/2019
        FUNCTION NOT IN USE CURRENTLY
        
        private void RefreshQueue()
        {
            ArrayList tempArr = new ArrayList();
            string tempStr = "";

            for (int i = 0; i < lstQueue.Items.Count; i++)
            {
                tempStr = lstQueue.Items[i].ToString().Substring(lstQueue.Items[i].ToString().IndexOf('-') + 2);
                //parsing the string to get rid of the time in the beginning.

                tempArr.Add(tempStr);
                
            }

            lstQueue.Items.Clear();
            
            for(int i = 0; i < hiddenData.Count; i++)
            {
                for(int j = 0; j < tempArr.Count; j++)
                {
                    if(((ProcessData)hiddenData[i]).winTitle == tempArr[j].ToString())
                    {
                        lstQueue.Items.Add(((ProcessData)hiddenData[i]).freq/60000 + "min - " + tempArr[j].ToString());
                        //add the new string with the data.
                        break;
                    }
                }
            }
        }
        */

        /*
        Target: SwapApp - Function
        Purpose: Handles changing the focus placed on
        windows. This is done using the individual handle that is
        assigned to the window. The interval for the timer is also
        controlled and set here. This is called on the btnSwapper click.
        If the process that is opened is Explorer or Edge, then we will
        close and reopen that process. This is done to refresh the content
        that is being shown on that page.
        Date: 6/3/2019
        Date-Last-Edited: 6/13/2019
        */
        private void SwapApp()
        {
            IntPtr handle = IntPtr.Zero;
            string tempStr = lstQueue.SelectedItem.ToString().Substring(lstQueue.SelectedItem.ToString().IndexOf('-') + 2);
            //parse and store the string without the time in the beginning.
            int pid = 0;

            const short SWP_NOACTIVATE = 0X0010;
            const short SWP_NOMOVE = 0X0002;
            const int SW_SHOWNORMAL = 1;
            const int SW_MAXIMIZE = 3;

            try
            {
                for (int i = 0; i < hiddenData.Count; ++i)
                {
                    if (((ProcessData)hiddenData[i]).winTitle == tempStr)
                    {
                        handle = ((ProcessData)hiddenData[i]).handle;
                        pid = int.Parse(((ProcessData)hiddenData[i]).id);
                        timerSwap.Interval = ((ProcessData)hiddenData[i]).freq;
                        //Grabbing the necessary data to perform a window swap.
                        break;
                    }
                }
            
                int chars = 256;
                StringBuilder buff = new StringBuilder(chars);

                IntPtr fHandle = GetForegroundWindow();
                //grab the window currently shown for comparison

                //this if statement checks to make sure that our window is valid
                if (GetWindowText(fHandle, buff, chars) > 0)
                {
                    if (handle != IntPtr.Zero)
                    {
                        SetForegroundWindow(handle);
                        //if the handle of the window is valid then we can go ahead and set
                        //it as the foreground window.

                        if(tempStr.ToLower() == "pluto tv")
                        {
                            if(chyronActive)
                            {
                                myScreen = Screen.FromHandle(handle);
                                //grab the screen that the window is on so that we can
                                //dynamically size the window according to screen size.

                                int trueHeight = (int)(myScreen.WorkingArea.Height * .15);
                                trueHeight = myScreen.WorkingArea.Height - trueHeight;
                                int trueWidth = myScreen.WorkingArea.Width;

                                if (handle != IntPtr.Zero)
                                {
                                    ShowWindowAsync(handle, SW_SHOWNORMAL);

                                    SetWindowPos(handle, 0, 0, 0, trueWidth, trueHeight, SWP_NOACTIVATE | SWP_NOMOVE);
                                }
                            }
                            else
                            {
                                ShowWindowAsync(handle, SW_MAXIMIZE);
                            }
                            
                        }

                        if (Process.GetProcessById(pid).ProcessName == "iexplore" || Process.GetProcessById(pid).ProcessName == "MicrosoftEdge") //I despise this method...
                        {
                            Process.GetProcessById(pid).Kill();
                            //since we are using IE to do a specific task with our prod metrics data
                            //in order to refresh this page I am simply closing it and reopening it every
                            //time it comes up in the queue.

                            for(int i = 0; i < hiddenData.Count; i++)
                            {
                                if(((ProcessData)hiddenData[i]).id == pid.ToString())
                                {
                                    ProcessData temp = (ProcessData)hiddenData[i];
                                    Process newData = Process.Start(@"C:\Program Files\Internet Explorer\iexplore.exe", "http://bowebtier:8080/BOE/OpenDocument/opendoc/openDocument.jsp?iDocID=4609440&sType=wid&sRefresh=Y&sWindow=Same?logonSuccessful=true&shareId=0&sOutputFormat=H");
                                    //start a new instance of IE with our link to be opened

                                    Cursor.Current = Cursors.WaitCursor;
                                    System.Threading.Thread.Sleep(10000);
                                    Cursor.Current = Cursors.Default;

                                    if (!newData.HasExited)
                                    {
                                        temp.id = newData.Id.ToString();
                                        temp.winTitle = newData.MainWindowTitle;
                                        temp.handle = newData.MainWindowHandle;
                                        temp.restart = false;
                                        temp.freq = ((ProcessData)hiddenData[i]).freq;

                                        hiddenData.RemoveAt(i);
                                        hiddenData.Insert(i, temp);
                                        //We have to essentially re-add the old item back into the list since we closed,
                                        //and re-opened it. the process data has been changed in doing this so the
                                        //new process data and new window handle need to be saved over the old.
                                    }

                                    int index = lstQueue.Items.IndexOf(((ProcessData)hiddenData[i]).freq / 60000 + "min" + " - " + ((ProcessData)hiddenData[i]).winTitle);
                                    lstQueue.Items.Remove(((ProcessData)hiddenData[i]).freq / 60000 + "min" + " - " + ((ProcessData)hiddenData[i]).winTitle);
                                    //We need to remove the old instance of the link from the list to be readded.

                                    lstQueue.Items.Insert(index, ((ProcessData)hiddenData[i]).freq / 60000 + "min" + " - " + ((ProcessData)hiddenData[i]).winTitle);
                                    lstQueue.SelectedItem = (((ProcessData)hiddenData[i]).freq / 60000 + "min" + " - " + ((ProcessData)hiddenData[i]).winTitle);
                                    //Re-add the item to the queue then reselect it.
                                    //This method has been known to mess up some.

                                    RefreshDropDown();
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        /*
        Target: BrowseFolder - Function
        Purpose: Handles the browsing and opening of folders
        and files. This is called on the btnBrowse click.
        Date: 6/6/2019
        Date-Last-Edited: 5/6/2019
        */
        private void BrowseFolder()
        {
            try
            {
                //The using statement ensures that no problems occur
                //when we invoke the new instance of the OpenFileDialog.
                using (var theDialog = new OpenFileDialog())
                {
                    theDialog.Title = "Select File to Open";

                    if (theDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(theDialog.FileName))
                    {
                        Process.Start(theDialog.FileName);

                        Cursor.Current = Cursors.WaitCursor;
                        System.Threading.Thread.Sleep(5000);
                        Cursor.Current = Cursors.Default;

                        RefreshProcesses();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*
        Target: AddQueue - Function
        Purpose: Handles adding items from the drop
        down list, to the queue. Alternatively this
        function opens new directories if typed in, or
        URLs if the user types it in.
        Date: 5/28/2019
        Date-Last-Edited: 6/12/2019
        */
        private void AddQueue()
        {
            //If the text is not empty but the selected item is also null
            //then we can safely assume that the user has typed something in
            //manually. Therefore we check to see if we can open it as a URL
            //or if it is a windows file path. Otherwise it's invalid.
            if (cmbProcesses.Text != "" && cmbProcesses.SelectedItem == null)
            {
                string url = cmbProcesses.Text;

                //I use a try catch here to do the opening because
                //An if statement would be bulky, when instead I can
                //do this and I get an error message and an execution.
                try
                {
                        Process.Start(url);
                }
                catch
                {
                    url = url.Replace("&", "^&");

                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }

                Cursor.Current = Cursors.WaitCursor;
                System.Threading.Thread.Sleep(2000);
                Cursor.Current = Cursors.Default;

                RefreshProcesses();
            }
            else if (cmbProcesses.SelectedItem != null)
            {
                lstQueue.Items.Add(((ProcessData)cmbProcesses.SelectedItem).freq/60000 + "min - " + ((ProcessData)cmbProcesses.SelectedItem).winTitle);
                lstQueue.SelectedIndex = lstQueue.Items.IndexOf(((ProcessData)cmbProcesses.SelectedItem).freq / 60000 + "min - " + ((ProcessData)cmbProcesses.SelectedItem).winTitle);
                //If there is an item selected then we just add that to the list and append the 
                //frequency onto the text at the beginning.
            }
            else
            {
                MessageBox.Show("Nothing selected to Add. Aborting!", "Nothing Selected");
            }  
        }

        /*
        Target: RemoveQueue - Function
        Purpose: Handles the removing of items from the
        listed queue.
        Date: 5/28/2019
        Date-Last-Edited: 6/10/2019
        */
        private void RemoveQueue()
        {
            if(lstQueue.SelectedItem == null)
            {
                MessageBox.Show("Nothing selected to remove. Aborting!", "Nothing Selected");
            }
            else
            {
                lstQueue.Items.Remove(lstQueue.SelectedItem);
            }
        }

        /*
        Target: ChyronControl - Function
        Purpose: Handles the window sizes for if the chyron
        is enabled or disabled. should calculate the size
        of the top windows based upon monitor size.
        Date: 6/4/2019
        Date-Last-Edited: 6/5/2019
        */
        private void ChyronControl()
        {
            //creating and initializing all the codes
            //we will need to send to the thread.
            const short SWP_NOACTIVATE = 0X0010;
            const short SWP_NOMOVE = 0X0002;
            const int SW_SHOWNORMAL = 1;
            const int SW_MAXIMIZE = 3;

            int trueHeight = 0;
            int trueWidth = 0;


            //These two following statements are nearly identical because the
            //method used to shorten the window is the same as it is to extend.
            if (chyronActive)
            {
                for (int i = 0; i < hiddenData.Count; ++i)
                {
                    for(int j = 0; j < lstQueue.Items.Count; ++j)
                    {
                        //for every iteration through the array and the list we check to see
                        //if there is a match inside the list to the array if so then we want to
                        //shorten that window for the chyron.
                        if (((ProcessData)hiddenData[i]).winTitle == lstQueue.Items[j].ToString().Substring(lstQueue.Items[j].ToString().IndexOf('-') + 2))
                        {
                            IntPtr wHandle = ((ProcessData)hiddenData[i]).handle;
                            //grab the handle of the window

                            //I don't think this fully works, but I could be wrong
                            if (IsWindowVisible(wHandle))
                            {
                                myScreen = Screen.FromHandle(wHandle);
                                //grab the screen that the window is on so that we can
                                //dynamically size the window according to screen size.

                                trueHeight = (int)(myScreen.WorkingArea.Height * .15);
                                trueHeight = myScreen.WorkingArea.Height - trueHeight;
                                trueWidth = myScreen.WorkingArea.Width;
                                //so the height of the screen should be 15% shorter then it's max size.
                                //we accomplish this by taking the screens height and multiplying it by 15%
                                //then using that to subtract 15% from the actual screen height.

                                if (wHandle != IntPtr.Zero)
                                {
                                    ShowWindowAsync(wHandle, SW_SHOWNORMAL);
                                    //This drops the window from being maximized if it is.

                                    SetWindowPos(wHandle, 0, 0, 0, trueWidth, trueHeight, SWP_NOACTIVATE | SWP_NOMOVE);
                                    //this then takes the window and keeps it where it is,
                                    //but changes the width and height according to screen size and our
                                    //subtraction of 15%.
                                    //using the code SWP_NOACTIVATE should keep the window in it's current position
                                    //on the z-axis. So it shouldn't mess with the active/foreground windows.
                                }
                            }
                        }  
                    }
                }
            }

            else if(!chyronActive)
            {
                for (int i = 0; i < hiddenData.Count; ++i)
                {
                    for(int j = 0; j < lstQueue.Items.Count; ++j)
                    {
                        //for every iteration through the array and the list we check to see
                        //if there is a match inside the list to the array if so then we want to
                        //shorten that window for the chyron.
                        if (((ProcessData)hiddenData[i]).winTitle == lstQueue.Items[j].ToString().Substring(lstQueue.Items[j].ToString().IndexOf('-') + 2))
                        {
                            IntPtr wHandle = ((ProcessData)hiddenData[i]).handle;
                            //grab the handle of the window

                            //I don't think this fully works, but I could be wrong
                            if (IsWindowVisible(wHandle))
                            {
                                if (wHandle != IntPtr.Zero)
                                {
                                    ShowWindowAsync(wHandle, SW_MAXIMIZE);
                                    //Using ShowWindowAsync() we can just maximize the window
                                }
                            }
                        }  
                    }
                }
            }

            else
            {
                if (chkChyron.Checked == true)
                {
                    MessageBox.Show("There is nothing in the list", "User Error");
                }
            }
        }

        /*
        Target: helpToolStripMenuItem_Click - EventHandler
        Purpose: Provides documentation and help with use of the application
        Date: 6/27/2019
        Date-Last-Edited: 6/27/2019
        */
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("START: \nTo use this application simply select an item from the drop down list and add it to the queue. " +
                "Once you have added an item to the queue you may change the frequency at which it changes by selecting the item from the queue and clicking the edit frequency button. " +
                "Once you are happy with your queue you may click the 'Start Swapping' button. To stop it just click the same button, but represented by the 'Stop Swapping' text. " +
                "\n\nOPEN/CLOSE: \nYou can also open and close applications. To open an application click the browse icon represented by '...' and find the application " +
                "or specific file you wish to open. To close an application just select the application you wish to close from the drop down list and click the 'Stop App' button. " +
                "\nNOTE: If you ever open an application externally, please always click the refresh button before continuing use of this application." +
                "\n\nCHYRON: \nThis application comes with built in Chyron/Marquee functionality. All you have to do to get started is to click the checkbox represented by 'Chyron?' " +
                "You will then find three textboxes and a button. You can enter up to three sentences to be displayed in the scrolling text, or you can have less than three " +
                "You have to have at least one. There must also be at least one item added to the queue for this to function. " +
                "\nOnce you've prepared your sentences you may click the 'Start Chyron' button and a second window will pop up. This window is setup to open on any secondary monitor " +
                "that you may have, but will work with single monitor setups as well! All you have to do is make sure that this window is in the background of all the windows in your queue. " +
                "\nNOTE: Please do not close this secondary window, if you wish to stop the chyron press the button designed to do so. " +
                "\n\nKNOWN ISSUES: One issue I have been unable to address is if you have two tabs of the same name open(for instance 'New Tab - Google Chrome'x2) the drop down list " +
                "can become confused as to which window is which in some situations since I have to use the window name to do a few different things. Realizing it's probably redundant for " +
                "the user to have multiple of one window open for this application, I decided that this bug was not a priority for now." +
                "\n\nIf there are any issues or bugs that you catch, please email me directly." +
                "\n\nThank you, \nJustin Taylor", "Help");
        } 
    }
}