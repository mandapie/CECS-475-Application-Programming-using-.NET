using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipMaintenanceMVVM.Message
{
    /// <summary>
    /// to transfer data between views
    /// </summary>
    class Messages
    {
        public string firstName
        {
            get; set;
        }
        public string lastName
        {
            get; set;
        }
        public string email
        {
            get; set;
        }
    }
}
