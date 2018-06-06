/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MembershipMaintenanceMVVM"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using MembershipMaintenanceMVVM.ViewModel;
using Microsoft.Practices.ServiceLocation;
using System.Windows;

namespace MembershipMaintenanceMVVM
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            //connects all ViewModels together
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AddMemberViewModel>();
            SimpleIoc.Default.Register<UpdateMemberViewModel>();
        }

        public MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public AddMemberViewModel AddMemberViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddMemberViewModel>();
            }
        }

        public UpdateMemberViewModel UpdateMemberViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UpdateMemberViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}