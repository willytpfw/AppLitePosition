﻿using AppLitePosition.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppLitePosition.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}