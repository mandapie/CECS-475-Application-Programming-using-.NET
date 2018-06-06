using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Membership_Maintenance_Form
{
    class MembershipData
    {
        /// <summary>
        /// file path to access "database" (.txt)
        /// </summary>
        private const string dir = @"C:\Users\Amanda\Documents\Visual Studio 2015\Projects\Fitness Membership Maintenance\";
        private const string file = dir + "MembershipData.txt";

        /// <summary>
        /// write each member from the list to the file
        /// </summary>
        /// <param name="members"></pn aram>
        public static void GetMemberships(MembershipList members)
        {
            // create the object for the input stream for a text file
            StreamReader inText = new StreamReader(file);
            try
            {
                // if the directory doesn't exist, create it
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
            }
            catch { }
            try
            {
                // read the data from the file and store it in the ArrayList
                string row;
                while (inText.Peek() != -1 || (row = inText.ReadLine()) != null)
                {
                    row = inText.ReadLine();
                    string[] columns = row.Split('|');
                    Member member = new Member(columns[0], columns[1], columns[2]);
                    members.Add(member);
                }
            }
            catch { }
            finally
            {
                inText.Close();
            }
        }

        /// <summary>
        /// write each member from the list to the file
        /// </summary>
        /// <param name="member"></param>
        public static void SaveMemberships(List<Member> member)
        {
            StreamWriter outText = new StreamWriter(file);
            //write each customer from the list to the file
            foreach (Member m in member)
            {
                outText.Write(m.firstName + "|");
                outText.Write(m.lastName + "|");
                outText.WriteLine(m.email);
            }
            //write the end of the document
            outText.Close();
        }
    }
}
