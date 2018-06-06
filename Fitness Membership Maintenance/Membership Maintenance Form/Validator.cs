using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Membership_Maintenance_Form
{
    /// <summary>
    /// checks if user inputs are valid
    /// </summary>
    public static class Validator
    {
        //title for the message box
        private static string title = "Entry Error";

        public static string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        /// <summary>
        /// checks if input is not empty
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        public static bool IsPresent(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(textBox.Tag + " is a required field.", Title);
                textBox.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// checks if input is a valid email
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        public static bool IsValidEmail(TextBox textBox)
        {
            if (textBox.Text.IndexOf("@") == -1 || textBox.Text.IndexOf(".") == -1)
            {
                MessageBox.Show(textBox.Tag + " must be a valid email address.", Title);
                textBox.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
