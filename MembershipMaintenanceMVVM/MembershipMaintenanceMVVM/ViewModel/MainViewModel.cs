using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;
using MembershipMaintenanceMVVM.Model;
using System.Collections.ObjectModel;
using System.Windows;
using MembershipMaintenanceMVVM.View;
using MembershipMaintenanceMVVM.Message;

namespace MembershipMaintenanceMVVM.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// windows
        /// </summary>
        AddMemberWindow addMemWindow;
        UpdateMemberWindow upMemWindow;

        /// <summary>
        /// properties
        /// </summary>
        private ObservableCollection<Member> members;
        private Member selectedMember;
        public ICommand AddMemberCommand { get; private set; }
        public ICommand DelMemberCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }

        public ObservableCollection<Member> MemberList
        {
            get
            {
                return members;
            }
        }
        public Member SelectedMember
        {
            get
            {
                return selectedMember;
            }
            set
            {
                selectedMember = value;
                RaisePropertyChanged("selectedMember");
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            members = new ObservableCollection<Member>();
            AddMemberCommand = new RelayCommand(AddMember);
            DelMemberCommand = new RelayCommand(DelMember);
            UpdateCommand = new RelayCommand(UpdateMember);
            ExitCommand = new RelayCommand(ExitAction);
            LoadMembers();
        }

        /// <summary>
        /// loads the list box
        /// </summary>
        public void LoadMembers()
        {
            this.RaisePropertyChanged(() => this.MemberList);
            Messenger.Default.Register<Member>(this, OnReceiveMessageAction);
        }

        /// <summary>
        /// checks if member exists already or not
        /// if none add it
        /// </summary>
        /// <param name="obj"></param>
        private void OnReceiveMessageAction(Member obj)
        {
            if(members.Contains(obj))
                MessageBox.Show("Member Already Exist");
            else
            {
                members.Add(obj);
                this.RaisePropertyChanged(() => this.MemberList);
            }
            Messenger.Default.Unregister<Member>(this, OnReceiveMessageAction);
            addMemWindow.Close();
        }

        /// <summary>
        /// opens the addMemberViewModel to add a new member
        /// </summary>
        public void AddMember()
        {
            addMemWindow = new AddMemberWindow();
            addMemWindow.DataContext = new AddMemberViewModel(new System.Action(() => addMemWindow.Close()));
            addMemWindow.Show();
            Messenger.Default.Register<Member>(this, OnReceiveMessageAction);
        }

        /// <summary>
        /// deletes the selected member
        /// </summary>
        public void DelMember()
        {
            if(MemberList.Count > 0)
            {
                MemberList.Remove(this.SelectedMember);
                this.RaisePropertyChanged(() => this.MemberList);
            }
        }

        /// <summary>
        /// updates selected member
        /// </summary>
        public void UpdateMember()
        {
            upMemWindow = new View.UpdateMemberWindow();
            UpdateMemberViewModel View = new UpdateMemberViewModel(new System.Action(() => upMemWindow.Close()));
            View.FNameText = SelectedMember.firstName;
            View.LNameText = SelectedMember.lastName;
            View.emailText = SelectedMember.email;
            upMemWindow.DataContext = View;
            upMemWindow.Show();
            Messenger.Default.Register<Messages>(this, OnReceiveMessageUAction);
        }

        /// <summary>
        /// replaces the selected member with new data
        /// </summary>
        /// <param name="obj"></param>
        private void OnReceiveMessageUAction(Messages obj)
        {
            Member m = new Member(obj.firstName, obj.lastName, obj.email);
            int i = MemberList.IndexOf(SelectedMember);
            MemberList[i] = m;
            this.RaisePropertyChanged(() => this.MemberList);
            Messenger.Default.Unregister<Messages>(this, OnReceiveMessageUAction);
        }

        /// <summary>
        /// exits the program
        /// </summary>
        public void ExitAction()
        {
            Application.Current.Shutdown();
        }
    }
}