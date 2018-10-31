
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DCC.SalesApp.Models;
using DevExpress.Mobile.DataGrid.Theme;
using DevExpress.Mobile.DataGrid;
using Default;
using Xamarin.Forms.Internals;

namespace DCC.SalesApp.Pages
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Customers : ContentPage
    {
        Default.Retailers oRetailer;

        Int32 _selectedRetailerID = -1;
        public Customers()
        {
            InitializeComponent();
            BindGrid();
            viewCustomer.grdCustomer.RowTap += GrdCustomer_RowTap;
        }
        private void GrdCustomer_RowTap(object sender, RowTapEventArgs e)
        {
            GridControl gridRow = (GridControl)sender;
            oRetailer = (Retailers)gridRow.SelectedDataObject;
            if (_selectedRetailerID != oRetailer.ID)
            {
                _selectedRetailerID = oRetailer.ID;
                Navigation.PushAsync(new CustomerDetails(oRetailer.ID) { Title = oRetailer.Name });
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _selectedRetailerID = -1;
        }
        public void BindGrid()
        {
            Theme.ApplyGridTheme();
            List<Customer> Retailerslist = App.Database.GetAllCustomerDetails().ToList();
            viewCustomer.grdCustomer.AutoFilterPanelHeight = 30;
            viewCustomer.grdCustomer.ItemsSource = Retailerslist;
            Theme.ApplyGridTheme();
            ThemeManager.RefreshTheme();
        }
    }
}