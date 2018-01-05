using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class homeOlive : Page
    {
        // g
         public List<Datum> res_data;
        public homeOlive()
        {

            this.InitializeComponent();

            getData();

        }

        public async void getData() {
            
            HttpClient httpClient = new HttpClient();

            string url = "http://localhost/cobapemvis/cobapemvis/viewProduct.php";

            HttpResponseMessage response = await httpClient.GetAsync(url);

            string responseText = await response.Content.ReadAsStringAsync();
            string jsonString = responseText;

            Debug.WriteLine(jsonString);

       
            var res = JsonConvert.DeserializeObject<ProductData>(responseText);
            res_data = res.data;
        }
       

        //move to another page
        private void productDetail_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ProductDetailPage));
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddProduct));

        }
    }
}
