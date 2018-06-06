using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using MembershipMaintenanceMVVM.Model;

namespace MembershipMaintenanceMVVM.ViewModel
{
    public class AddMemberViewModel : ViewModelBase
    {
        /// <summary>
        /// properties
        /// </summary>
        Member newMember;
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; private set; }
        public object Mesenger { get; private set; }
        string fn, ln, em;
        public string FNameText
        {
            get
            { return fn; }

            set
            {
                fn = value;
                RaisePropertyChanged("FNameText");
            }
        }
        public string LNameText
        {
            get
            { return ln; }

            set
            {
                ln = value;
                RaisePropertyChanged("LNameText");
            }
        }
        public string emailText
        {
            get
            { return em; }

            set
            {
                em = value;
                RaisePropertyChanged("emailText");
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        public AddMemberViewModel(Action exit)
        {
            SaveCommand = new RelayCommand(SaveCommandAction);
            CancelCommand = new RelayCommand(exit);
        }

        /// <summary>
        /// method to send the data back to the mainviewmodel
        /// </summary>
        public void SaveCommandAction()
        {
            newMember = new Member(FNameText, LNameText, emailText);
            Messenger.Default.Send(newMember);
        }
    }
}
