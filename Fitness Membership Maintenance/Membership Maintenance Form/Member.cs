using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership_Maintenance_Form
{
    /// <summary>
    /// contains first name, last name, and email of a member
    /// </summary>
    class Member : IEquatable<Member>
    {
        //Attributes
        private string _FName, _LName, _Email;

        /// <summary>
        /// Constructors
        /// </summary>
        //Default constructor
        public Member()
        {
            _FName = "";
            _LName = "";
            _Email = "";
        }
        //Argument constructor
        public Member(string FName, string LName, string Email)
        {
            _FName = FName;
            _LName = LName;
            _Email = Email;
        }

        /// <summary>
        /// Property methods
        /// </summary>
        //firstName property
        public string firstName
        {
            get
            {
                return _FName;
            }
            set
            {
                if (_FName.Length > 25)
                {
                    throw new System.ArgumentOutOfRangeException("First name cannot be longer than 25 characters");
                }
                _FName = value;
            }
        }
        //lastName property
        public string lastName
        {
            get
            {
                return _LName;
            }
            set
            {
                if (_LName.Length > 25)
                {
                    throw new System.ArgumentOutOfRangeException("Last name cannot be longer than 25 characters");
                }
                _LName = value;
            }
        }
        //email property
        public string email
        {
            get
            {
                return _Email;
            }
            set
            {
                if (_Email.Length > 25)
                {
                    throw new System.ArgumentOutOfRangeException("Email cannot be longer than 25 characters");
                }
                _Email = value;
            }
        }

        /// <summary>
        /// returns a string in a row of the repective order
        /// </summary>
        /// <returns>
        /// first name, last name, email
        /// </returns>
        public string GetDisplayText() => firstName + " " + lastName + " " + email;

        /// <summary>
        /// override the Equals function to compare attributes in the Member object
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Member other)
        {
            return this._FName == other._FName && this._LName == other._LName && this._Email == other._Email;
        }
    }
}
