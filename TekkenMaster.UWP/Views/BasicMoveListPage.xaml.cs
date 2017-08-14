using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TekkenMaster.UWP.ViewModels;
using System.ComponentModel;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace TekkenMaster.UWP.Views
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class BasicMoveListPage : Page
    {
        public BasicMoveListPage()
        {
            this.InitializeComponent();
            DataContextChanged += MainPage_DataContextChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public BasicMoveListViewModel ConcreteDataContext
        {
            get
            {
                return DataContext as BasicMoveListViewModel;
            }
        }

        private void MainPage_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(nameof(ConcreteDataContext)));
            }
        }
    }
}
