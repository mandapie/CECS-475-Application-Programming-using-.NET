using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Membership_Maintenance_Form
{
    public partial class AddMForm : Form
    {
        private Member member;

        public AddMForm()
        {
            InitializeComponent();
        }

        internal Member GetNewMember()
        {
            this.ShowDialog();
            return member;
        }

        private void AddMForm_Load(object sender, EventArgs e)
        {

        }

        private void FNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmailBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(IsValidData())
            {
                member = new Member(FNameBox.Text, LNameBox.Text, EmailBox.Text);
                this.Close();
            }
        }

        bool IsValidData()
        {
            if (Validator.IsPresent(FNameBox) == false || Validator.IsPresent(LNameBox) == false || Validator.IsPresent(EmailBox) == false)
                return false;
            if (Validator.IsValidEmail(EmailBox) == false)
                return false;
            return true;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            string message = "Cancel this entry?";
            DialogResult button = MessageBox.Show(message, "Confirm Delete", MessageBoxButtons.YesNo);
            if (button == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
