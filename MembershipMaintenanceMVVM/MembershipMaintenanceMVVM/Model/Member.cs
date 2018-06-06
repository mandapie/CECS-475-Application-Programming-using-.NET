using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MembershipMaintenanceMVVM.Model
{
    /// <summary>
    /// contains first name, last name, and email of a member
    /// </summary>
    public class Member : ObservableObject, IEquatable<Member>
    {
        //Attributes
        private string _FName, _LName, _Email;

        /// <summary>
        /// Constructors
        /// </summary>
        //Default constructor
        public Member()
        {
            _FName = "Hi";
            _LName = "YOU";
            _Email = "HI";
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
                Set<string>(() => this.firstName, ref _FName, value);
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
                Set<string>(() => this.lastName, ref _LName, value);
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
                Set<string>(() => this.email, ref _Email, value);
            }
        }

        /// <summary>
        /// returns a string in a row of the repective order
        /// </summary>
        /// <returns>
        /// first name, last name, email
        /// </returns>
        public string GetDisplayText
        {
            get
            {
                return firstName + " " + lastName + " " + email;
            }
        }

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