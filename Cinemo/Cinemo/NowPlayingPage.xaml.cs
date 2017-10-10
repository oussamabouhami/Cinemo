using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Cinemo.Models;

namespace Cinemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NowPlayingPage : ContentPage
    {
        public NowPlayingPage()
        {
            InitializeComponent();
            GetMovies();
        }

        /* public async void GetMovies()
         {
             //SLMovies.IsVisible = false;
             try
             {
                 SLMovies.IsVisible = true;
                 HttpClient client = new HttpClient();
                 var response = await client.GetStringAsync("http://cinemo.azurewebsites.net/api/NowPlayingMovies");

                 var movies = JsonConvert.DeserializeObject<List<NowPlaying>>(response);

                 MovieListView.ItemsSource = movies;

             }
             catch
             {
                 //SLMovies.IsVisible = false;
                 throw;
             }
             finally
             {
                 SLMovies.IsVisible = false;
             }
         } */


        public async Task<List<NowPlaying>> GetMovies()
        {
            SLMovies.IsVisible = false;

            try
            {
                SLLoader.IsVisible = true;
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://cinemo.azurewebsites.net/api/NowPlayingMovies");
                var movies = JsonConvert.DeserializeObject<List<NowPlaying>>(response);
                MovieListView.ItemsSource = movies;
                SLMovies.IsVisible = true;

                return movies;

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