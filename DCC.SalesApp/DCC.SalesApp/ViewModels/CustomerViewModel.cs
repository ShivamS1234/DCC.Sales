using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using DCC.SalesApp.Models;

namespace DCC.SalesApp.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        public ObservableCollection<Customer> _retailerLists;
        public ObservableCollection<Customer> RetailerLists
        {
            get { return _retailerLists; }
            set
            {
                if (value != null)
                {
                    _retailerLists = value;
                    this.OnPropertyChanged("RetailerLists");
                }
            }
        }
        public CustomerViewModel()
        {
            RetailerLists = new ObservableCollection<Customer>();
            GetCustomerList();

        }

        public void GetCustomerList()
        {
            List<Customer> Retailerslist = App.Database.GetAllCustomerDetails().ToList();
            if (Retailerslist != null)
            {
                foreach (var cutomerData in Retailerslist)
                {
                    RetailerLists.Add(cutomerData);
                }
            }
        }
    }
}