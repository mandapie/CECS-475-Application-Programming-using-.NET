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
using MembershipMaintenanceMVVM.Message;

namespace MembershipMaintenanceMVVM.ViewModel
{
    public class UpdateMemberViewModel : ViewModelBase
    {
        /// <summary>
        /// properties to bind to the view
        /// </summary>
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
        public Action Exit { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// constructor of the view model
        /// </summary>
        /// <param name="exit"></param>
        public UpdateMemberViewModel(Action exit)
        {
            Exit = exit;
            UpdateCommand = new RelayCommand(UpdateCommandAction);
            CancelCommand = new RelayCommand(exit);
        }

        /// <summary>
        /// sends data to the mainview model
        /// </summary>
        /// <param name="exit"></param>
        public void UpdateCommandAction()
        {
            var messagesMem = new Messages();
            messagesMem.firstName = FNameText;
            messagesMem.lastName = LNameText;
            messagesMem.email = emailText;
            Messenger.Default.Send(messagesMem);
            Exit();
        }
    }
}
