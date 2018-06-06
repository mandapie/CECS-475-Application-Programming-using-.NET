using GalaSoft.MvvmLight;
using CustomerMaintenanceMVVM.Model;
using CustomerMaintenanceMVVM.View;
using System;
using System.Linq;
using System.Windows.Input;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using System.Data.Entity.Infrastructure;
using System.Data;
using GalaSoft.MvvmLight.Messaging;

namespace CustomerMaintenanceMVVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// properties
        /// </summary>
        AddUpdateWindow addWin, modWin;
        Customer selectedCustomer;
        string id, name, addr, city, state, zip;
        public string IDText
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                RaisePropertyChanged("IDText");
            }
        }
        public string NameText
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged("NameText");
            }
        }
        public string AddrText
        {
            get
            {
                return addr;
            }
            set
            {
                addr = value;
                RaisePropertyChanged("AddrText");
            }
        }
        public string CityText
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
                RaisePropertyChanged("CityText");
            }
        }
        public string StateText
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                RaisePropertyChanged("StateText");
            }
        }
        public string ZipText
        {
            get
            {
                return zip;
            }
            set
            {
                zip = value;
                RaisePropertyChanged("ZipText");
            }
        }
        public ICommand GetCustomer { get; set; }
        public ICommand Add { get; set; }
        public ICommand Mod { get; set; }
        public ICommand Del { get; set; }
        public ICommand Exit { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            GetCustomer = new RelayCommand(GetCustomerMethod);
            Add = new RelayCommand(AddMethod);
            Mod = new RelayCommand(ModMethod);
            Del = new RelayCommand(DelMethod);
            Exit = new RelayCommand(ExitMethod);
        }

        /// <summary>
        /// get customer info
        /// </summary>
        public void GetCustomerMethod()
        {
            int custID = Convert.ToInt32(IDText);
            RetrieveCustomer(custID);
        }
        public void RetrieveCustomer(int ID)
        {
            try
            {
                var getCust = from customer in MMABooksEntity.MMABooks.Customers
                              where customer.CustomerID == ID
                              select customer;
                selectedCustomer = getCust.Single();
                if (selectedCustomer == null)
                {
                    MessageBox.Show("Customer not Found");
                    IDText = "";
                }
                else
                {
                    // If the customer is found, add code to the GetCustomer method that checks if the State object
                    // has been loaded and that loads if it hasn't.
                    if (MMABooksEntity.MMABooks.Entry(selectedCustomer).Reference("State1").IsLoaded == false)
                        MMABooksEntity.MMABooks.Entry(selectedCustomer).Reference("State1").Load();
                    DisplayCustomer();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
        public void DisplayCustomer()
        {
            NameText = selectedCustomer.Name;
            AddrText = selectedCustomer.Address;
            CityText = selectedCustomer.City;
            StateText = selectedCustomer.State1.StateName;
            ZipText = selectedCustomer.ZipCode;
        }

        /// <summary>
        /// adds a new customer
        /// </summary>
        public void AddMethod()
        {
            addWin = new AddUpdateWindow();
            Message addCust = new Message();
            addCust.isAdd = true;
            Messenger.Default.Send(addCust);
            addWin.Show();
            Messenger.Default.Register<NotificationMessage>(this, (msg) => {
                if (msg.Notification == "Close")
                {
                    addWin.Close();
                    Messenger.Default.Register<Customer>(this, finish);
                }
            });
        }
        private void finish(Customer m)
        {
            try
            {
                selectedCustomer = m;
                if(MMABooksEntity.MMABooks.Entry(selectedCustomer).State == EntityState.Detached)
                {
                    IDText = "";
                    Empty();
                }
                else
                {
                    IDText = selectedCustomer.CustomerID.ToString();
                    DisplayCustomer();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// modifies a customer
        /// </summary>
        public void ModMethod()
        {
            modWin = new AddUpdateWindow();
            Message modCust = new Message();
            modCust.isAdd = false;
            //modCust.id = selectedCustomer.CustomerID;
            modCust.c = selectedCustomer;
            Messenger.Default.Send(modCust);
            modWin.Show();
            Messenger.Default.Register<NotificationMessage>(this, (msg) => {
                if (msg.Notification == "Close")
                {
                    modWin.Close();
                    Messenger.Default.Register<Customer>(this, finish);
                }
            });
        }

        /// <summary>
        /// deletes a customer
        /// </summary>
        public void DelMethod()
        {
            MessageBoxResult result = MessageBox.Show("Delete " + selectedCustomer.Name + "?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                try
                {
                    MMABooksEntity.MMABooks.Customers.Remove(selectedCustomer);
                    MMABooksEntity.MMABooks.SaveChanges();
                    IDText = "";
                    Empty();
                }
                // concurrency error handling.
                catch (DbUpdateConcurrencyException ex)
                {
                    ex.Entries.Single().Reload();
                    if (MMABooksEntity.MMABooks.Entry(selectedCustomer).State == EntityState.Detached)
                    {
                        MessageBox.Show("Another User has deleted" + "that customer", "Concurrency Error");
                        IDText = "";
                        Empty();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }
        public void Empty()
        {
            NameText = "";
            AddrText = "";
            CityText = "";
            StateText = "";
            ZipText = "";
        }

        /// <summary>
        /// exits the application
        /// </summary>
        public void ExitMethod()
        {
            Application.Current.Shutdown();
        }
    }
}