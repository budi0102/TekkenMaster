using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Prism.Unity.Windows;

namespace TekkenMaster.UWP.Services
{
    public class BaseDialogAsyncService : IDialogAsyncService
    {
        public ContentDialogResult ContentDialogResult { get; protected set; }
        public bool? DialogResult
        {
            get
            {
                bool? result = null;
                switch (this.ContentDialogResult)
                {
                    case ContentDialogResult.Primary:
                        result = true;
                        break;
                    case ContentDialogResult.Secondary:
                        result = false;
                        break;
                    case ContentDialogResult.None:
                    default:
                        result = null;
                        break;
                }
                return result;
            }
        }
        public ContentDialog DialogView { get; protected set; }
        public ViewModelBase DialogViewModel { get; protected set; }

        public BaseDialogAsyncService()
        {
            this.ContentDialogResult = ContentDialogResult.None;
            this.DialogView = null;
            this.DialogViewModel = null;
        }

        public void Initialize<TV, TVm>()
            where TV : ContentDialog, new()
            where TVm : ViewModelBase, new()
        {
            this.DialogView = App.Current.Container.TryResolve<TV>() ?? new TV();
            this.DialogViewModel = App.Current.Container.TryResolve<TVm>() ?? new TVm();
            this.DialogView.DataContext = this.DialogViewModel;
        }

        public async Task<bool?> ShowDialogAsync()
        {
            this.ContentDialogResult = ContentDialogResult.None;
            this.ContentDialogResult = await this.DialogView.ShowAsync();
            return this.DialogResult;
        }
    }
}
