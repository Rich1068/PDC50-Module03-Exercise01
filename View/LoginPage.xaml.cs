using System;
using Microsoft.Maui.Controls;

namespace Module02Exercise01.View
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            if (username == "admin" && password == "admin")
            {
                try
                {
                    await Shell.Current.GoToAsync("//EmployeePage");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "OK");
                }
                
            }
            else
            {
                await DisplayAlert("Login Failed", "Invalid username or password. The username and password is admin admin", "OK");
            }
        }
    }
}
