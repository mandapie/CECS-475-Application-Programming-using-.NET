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
    public partial class MMForm : Form
    {
        public MMForm()
        {
            InitializeComponent();
        }

        private MembershipList members = new MembershipList();

        private void MMForm_Load(object sender, EventArgs e)
        {
            members.Changed += new MembershipList.ChangeHandler(HandleChange);
            members.Fill();
            FillMemberListBox();
        }

        private void FillMemberListBox()
        {
            Member m;
            ListBoxLabel.Items.Clear();
            for(int i = 0; i < members.Count; i++)
            {
                m = members[i];
                ListBoxLabel.Items.Add(m.GetDisplayText());
            }
        }

        private void HandleChange(MembershipList members)
        {
            members.Save();
            FillMemberListBox();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddMForm AddMember = new AddMForm();
            Member member = AddMember.GetNewMember();
            if (member != null)
            {
                members += member;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int MemberNum = ListBoxLabel.SelectedIndex;
            if (MemberNum != -1)
            {
                Member member = members[MemberNum];
                string message = "Are you sure you want to delete " + member.firstName + " " + member.lastName + "?";
                DialogResult button = MessageBox.Show(message, "Confirm Delete", MessageBoxButtons.YesNo);
                if (button == DialogResult.Yes)
                {
                    members -= member;
                }
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            string message = "Exit this console?";
            DialogResult button = MessageBox.Show(message, "Confirm Exit", MessageBoxButtons.YesNo);
            if (button == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ListBoxLabel_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
