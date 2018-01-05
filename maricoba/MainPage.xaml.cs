using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace maricoba
{
   
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
     
        public MainPage()
        {

            
            this.InitializeComponent();
        }
        string base_url = "http://localhost/cobapemvis/cobapemvis/login.php/";


        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = tbUsername.Text;
            string password = tbPassword.Password;

            HttpClient httpClient = new HttpClient();

            string url = base_url + "login";
            string param = "email=" + email + "&password=" + password;

            HttpResponseMessage response = await httpClient.PostAsync(url, new StringContent(param, Encoding.UTF8, "application/x-www-form-urlencoded"));
           
            string responseText = await response.Content.ReadAsStringAsync();
            string jsonString = responseText;

            Debug.WriteLine(jsonString);

            var res = JsonConvert.DeserializeObject<Rootobject>(responseText);

            string message;

            if (res.success == 1)
            {
                message = "success!";
                Frame.Navigate(typeof(homeOlive));

            }
            else
            {
                message = "fail!";
            }

            message += res.message;
            MessageDialog dialog = new MessageDialog(message);
            await dialog.ShowAsync();

        }

       
        private void btnRegis_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegisterPage));
        }
    }
}
