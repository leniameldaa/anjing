using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace maricoba
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {
        public RegisterPage()
        {
              

            this.InitializeComponent();
        }

        string base_url = "http://localhost/cobapemvis/cobapemvis/signup.php/";


        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string email = tbEmail.Text;
            string password = tbPassword.Password;
            string fullname = tbFN.Text;
            string address = tbAddress.Text;
           

           


            HttpClient httpClient = new HttpClient();

            string url = base_url + "register";
            string param = "email=" + email + "&fullname=" + fullname + "&password=" + password + "&address=" + address;

            HttpResponseMessage response = await httpClient.PostAsync(url, new StringContent(param, Encoding.UTF8, "application/x-www-form-urlencoded"));

            string responseText = await response.Content.ReadAsStringAsync();
            string jsonString = responseText;

            Debug.WriteLine(jsonString);

            var res = JsonConvert.DeserializeObject<Register>(responseText);

            string message;

            if (res.success == 1)
            {
                message = "success!";
            }
            else
            {
                message = "fail!";
            }

            message += res.message;
            MessageDialog dialog = new MessageDialog(message);
            await dialog.ShowAsync();
        }

        
    }
}
