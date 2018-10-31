
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DCC.SalesApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerList : ContentPage
    {
        public CustomerList()
        {
            InitializeComponent();
            listView.ItemsSource = App.database.GetAllCustomer();
        }
    }
}