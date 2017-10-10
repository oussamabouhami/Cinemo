using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpComingPage : ContentPage
    {
        public UpComingPage()
        {
            InitializeComponent();
            GetUpComingMovies();
        }

        public async Task<List<UpComingPage>> GetUpComingMovies()
        {
            SLMovies.IsVisible = false;

            try
            {
                SLLoader.IsVisible = true;
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://cinemo.azurewebsites.net/api/UpComingMovies");
                var employees = JsonConvert.DeserializeObject<List<UpComingPage>>(response);
                MovieListView.ItemsSource = employees;
                SLMovies.IsVisible = true;

                return employees;

            }
            catch (Exception e)
            {
                SLLoader.IsVisible = false;
                throw;
            }
            finally
            {
                SLLoader.IsVisible = false;
            }
        }
    }
}