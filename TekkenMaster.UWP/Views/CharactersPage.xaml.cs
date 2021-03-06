﻿using System.ComponentModel;
using TekkenMaster.UWP.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace TekkenMaster.UWP.Views
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class CharactersPage : UserControl, INotifyPropertyChanged
    {
        public CharactersPage()
        {
            this.InitializeComponent();
            DataContextChanged += DataContextChangedHandler;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public CharactersPageViewModel ConcreteDataContext
        {
            get
            {
                return DataContext as CharactersPageViewModel;
            }
        }

        private void DataContextChangedHandler(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(nameof(ConcreteDataContext)));
            }
        }
    }
}
