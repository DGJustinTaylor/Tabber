using System;
using System.Drawing;
using System.Windows.Forms;

/*
    Programmer: Justin Taylor
    Date: 5/28/2019
    Date-Last-Edited: 6/13/2019
*/

namespace Tabber
{
    public partial class frmEditFreq : Form
    {
        public int secondsFreq = 0;

        public frmEditFreq()
        {
            InitializeComponent();
        }

        private void frmEditFreq_Load(object sender, EventArgs e)
        {
            txtEditFreq.Text = (frmTab.processDataToEdit.freq / 60000).ToString();
        }

        /*
         Target: btnConfirm_Click - EventHandler 
         Purpose: Control the validation of the frequency
         editor and to store the new frequency inside of a 
         variable to be used on the previous page for
         assignment.
         Date: 5/28/2019
         Date-Last-Edited: 6/13/2019
        */
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(txtEditFreq.Text == "")
            {
                txtEditFreq.ForeColor = Color.Red;
                txtEditFreq.Text = "Invalid input";
            }
            else if(!int.TryParse(txtEditFreq.Text, out secondsFreq))
            {
                txtEditFreq.ForeColor = Color.Red;
                txtEditFreq.Text = "Numeric input required";
            }
            else if(int.Parse(txtEditFreq.Text) <= 0)
            {
                txtEditFreq.ForeColor = Color.Red;
                txtEditFreq.Text = "Input greater than 0 required";
            }
            else
            {
                secondsFreq = Int32.Parse(txtEditFreq.Text);

                Cursor.Current = Cursors.WaitCursor;
                System.Threading.Thread.Sleep(500);
                Cursor.Current = Cursors.Default;

                MessageBox.Show("Changes successful!", "Applying Changes");

                this.Close();
            }
        }
    }
}
