using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership_Maintenance_Form
{
    /// <summary>
    /// a list to store a member class
    /// </summary>
    class MembershipList
    {
        //list attribute to store 
        private List<Member> members;

        /// <summary>
        /// delegate a declaration and
        /// declare the event
        /// </summary>
        /// <param name="members"></param>
        public delegate void ChangeHandler(MembershipList members);
        public event ChangeHandler Changed;

        /// <summary>
        /// Constructor list
        /// </summary>
        public MembershipList()
        {
            members = new List<Member>();
        }

        /// <summary>
        /// counts for indexer position
        /// </summary>
        public int Count => members.Count;
        //indexer properties
        public Member this[int i]
        {
            get
            {
                return members[i];
            }
            set
            {
                members[i] = value;
                Changed(this);
            }
        }

        /// <summary>
        /// Fill the list with membership data from the Membership data
        /// from a file using the GetMemberships method of the
        /// MembershipData class
        /// </summary>
        public void Fill() => MembershipData.GetMemberships(this);

        /// <summary>
        /// Saves the memberships to a file using the SaveMemberships
        /// method of the MembershipData class
        /// </summary>
        public void Save() => MembershipData.SaveMemberships(members);

        /// <summary>
        /// Adds a specified Member object to the list
        /// </summary>
        /// <param name="m"></param>
        public void Add(Member m)
        {
            if (members.Contains(m))
            {
                throw new ArgumentException("Member already exists");
            }
            members.Add(m);
            Changed(this);
        }

        /// <summary>
        /// each new Member object is added to the indexer
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Member GetMemberByIndex(int i) => members[i];

        /// <summary>
        /// Removes the specified Member object from the list
        /// </summary>
        /// <param name="m"></param>
        public void Remove(Member m)
        {
            members.Remove(m);
            Changed(this);
        }

        /// <summary>
        /// overloading operators
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns>
        /// a new memership list
        /// </returns>
        //overload + with add method
        public static MembershipList operator +(MembershipList m1, Member m2)
        {
            m1.Add(m2);
            return m1;
        }
        //overload - with remove method
        public static MembershipList operator -(MembershipList m1, Member m2)
        {
            m1.Remove(m2);
            return m1;
        }

        /// <summary>
        /// check if the list contains an object
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public bool Contains(Member m)
        {
            return members.Contains(m);
        }

    }
}
