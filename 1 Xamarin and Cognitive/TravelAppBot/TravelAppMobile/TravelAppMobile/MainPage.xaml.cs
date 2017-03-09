﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelAppMobile.Animations;
using TravelAppMobile.ViewModels;
using Xamarin.Forms;

namespace TravelAppMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var viewModel = (MainPageViewModel)BindingContext;

            viewModel.ToggleMenuAction = () =>
            {
                if (MainViewGrid.TranslationX == 0)
                {
                    ToggleMenu(0, 210, 1, 0.6);
                }
                else
                {
                    ToggleMenu(210, 0, 0.6, 1);
                }
            };
        }

        private void ToggleMenu(double tranXFrom, double tranXTo, double scaleFrom, double scaleTo)
        {
            var animate1 = CommonAnimations.TransLateXAnimation(MainViewGrid, tranXFrom, tranXTo);
            var animate2 = CommonAnimations.ScaleAnimation(MainViewGrid, scaleFrom, scaleTo);

            this.Animate("tranx", animate1, 16, 200, Easing.Linear, (d, f) => { });
            this.Animate("scale", animate2, 16, 200, Easing.Linear, (d, f) => { });
        }

        private void Menu_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listView = (ListView)sender;

            ToggleMenu(210, 0, 0.6, 1);

            if (listView.SelectedItem != null)
                listView.SelectedItem = null;
        }

        private void Message_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listView = (ListView)sender;

            if (listView.SelectedItem != null)
                listView.SelectedItem = null;
        }
    }
}
