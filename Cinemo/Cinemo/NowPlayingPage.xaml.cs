﻿using System;
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

        public async void GetMovies()
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

            }
            catch (Exception)
            {
                SLLoader.IsVisible = false;
                throw;
            }
            finally
            {
                SLLoader.IsVisible = false;

            }
        }

        private void MovieListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem as NowPlaying;

            if (selectedItem != null){
                var movieId = selectedItem.MovieId;
                Navigation.PushAsync(new MoviesDetail(movieId));

            }
            ((ListView)sender).SelectedItem = null;
        }
    }
}