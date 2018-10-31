using System;
using Xamarin.Forms;
using Acr.UserDialogs;
using System.Threading.Tasks;

namespace DCC.SalesApp.Pages
{
    public partial class Login : ContentPage
    {

        public Login()
        { 
            InitializeComponent();
         
        }
         
        private async Task HandleClickAsync()
        { 
            var oUser = await App.PCManager.RefreshUserAsync(Email.Text).ConfigureAwait(true);
            if (oUser != null)
            {
                if (Password.Text == oUser.Password)
                {
                    // App.Database.SaveUserDetails(oUser.Result);
                    try
                    {
                        Application.Current.Properties["ID"] = oUser.ID;
                        Application.Current.Properties["Code"] = oUser.Code;
                        Application.Current.Properties["Email"] = oUser.Email;
                        App.Current.MainPage = new DCC.SalesApp.Pages.UserSafety();                        
                        // App.Current.MainPage = new MainPage();
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Error !!", ex.Message, "OK");
                    }
                }
                else
                    await DisplayAlert("Invalid Crendetials!", "It's seems that you have entered an incorrect email or password. Please try again.", "OK");

            }
            else
                await DisplayAlert("Invalid Crendetials!", "It's seems that you have entered an incorrect email or password. Please try again.", "OK");

        }


        private async void LoginClicked(object sender, EventArgs e)
        {  
            UserDialogs.Instance.ShowLoading("Loading ...", MaskType.Black);
            LoginButton.IsEnabled = false;
            try
            {
                // Can't use ConfigureAwait here.
                await HandleClickAsync(); 
            }
            finally
            {
                // We are back on the original context for this method.
                LoginButton.IsEnabled = true;
                UserDialogs.Instance.HideLoading();
            }
        }

        private async void SettingClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new UserSettingPage());
        }
    }
}