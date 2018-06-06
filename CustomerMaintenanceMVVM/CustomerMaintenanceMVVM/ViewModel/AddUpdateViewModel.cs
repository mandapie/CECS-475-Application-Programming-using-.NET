using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using CustomerMaintenanceMVVM.Model;
using CustomerMaintenanceMVVM.View;
using System.Windows.Input;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using System.Data.Entity.Infrastructure;
using System.Data;
using GalaSoft.MvvmLight.Messaging;

namespace CustomerMaintenanceMVVM.ViewModel
{
    public class AddUpdateViewModel : ViewModelBase
    {
        /// <summary>
        /// properties
        /// </summary>
        public bool addCust;
        public Customer customer;
        string title, name, addr, city, state, zip;
        public string TitleText
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                RaisePropertyChanged("TitleText");
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
        public List<State> StateCombo { get; set; }
        public string selectedState
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                RaisePropertyChanged("selectedState");
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
        public ICommand Save { get; set; }
        public ICommand Cancel { get; set; }

        /// <summary>
        /// Initializes a new instance of the AddUpdateViewModel class.
        /// </summary>
        public AddUpdateViewModel()
        {
            LoadComboBox();
            Messenger.Default.Register<Message>(this, windowTitle);
            Save = new RelayCommand(SaveMethod);
            Cancel = new RelayCommand(CancelMethod);
        }
        public void LoadComboBox()
        {
            try
            {
                var resultsByStates =
                       (from state in MMABooksEntity.MMABooks.States
                        orderby state.StateName
                        select state).ToList();
                StateCombo = resultsByStates;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
        private void windowTitle(Message c)
        {
            //Mod
            if (c.isAdd == false)
            {
                addCust = false;
                TitleText = "Modify Customer";
                getCust(c.c);
            }
            //Add
            else
            {
                addCust = true;
                TitleText = "Add Customer";
                Empty();
            }
        }
        private void getCust(Customer c)
        {
            try
            {
                customer = c;
                if (customer == null)
                {
                    MessageBox.Show("Customer not found");
                }
                else
                {
                    DisplayCustomerData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
        public void DisplayCustomerData()
        {
            NameText = customer.Name;
            AddrText = customer.Address;
            CityText = customer.City;
            selectedState = customer.State1.StateCode; //valuepath
            ZipText = customer.ZipCode;
        }
        public void Empty()
        {
            NameText = "";
            AddrText = "";
            CityText = "";
            selectedState = "";
            ZipText = "";
        }

        /// <summary>
        /// saves customer to database
        /// </summary>
        public void SaveMethod()
        {
            //Add
            if (addCust == true)
            {
                customer = new Customer();
                PutCustomerData(customer);
                MMABooksEntity.MMABooks.Customers.Add(customer);
                try
                {
                    MMABooksEntity.MMABooks.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
            //Mod
            else
            {
                PutCustomerData(customer);
                try
                {
                    MMABooksEntity.MMABooks.SaveChanges();
                }
                // concurrency error handling.
                catch (DbUpdateConcurrencyException ex)
                {
                    ex.Entries.Single().Reload();
                    if (MMABooksEntity.MMABooks.Entry(customer).State == EntityState.Unchanged)
                    {
                        MessageBox.Show("Another user has updated that customer", "Concurrency Error");
                    }
                    else if (MMABooksEntity.MMABooks.Entry(customer).State == EntityState.Detached)
                    {
                        MessageBox.Show("Another user has deleted that customer", "Concurrency Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(this, "Close"));
            Messenger.Default.Send<Customer>(customer);
        }
        private void PutCustomerData(Customer c)
        {
            c.Name = NameText;
            c.Address = AddrText;
            c.City = CityText;
            c.State = selectedState.ToString();
            c.ZipCode = ZipText;
        }

        /// <summary>
        /// cancel everything and close window
        /// </summary>
        public void CancelMethod()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(this, "Close"));
        }
    }
}
