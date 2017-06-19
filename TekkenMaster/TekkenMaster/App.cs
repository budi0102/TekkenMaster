#if __ANDROID__
using TekkenMaster.Droid;
#elif __IOS__
using TekkenMaster.iOS.Helpers;
#elif WINDOWS_UWP
using TekkenMaster.UWP.Helpers;
#endif
using TekkenMaster.Helpers;
using TekkenMaster.Interfaces;
using TekkenMaster.Services;
using TekkenMaster.Model;

namespace TekkenMaster
{
    public partial class App 
    {
        public App()
        {
        }

        public static void Initialize()
        {
            ServiceLocator.Instance.Register<IDataStore<Item>, MockDataStore>();
            ServiceLocator.Instance.Register<IMessageDialog, MessageDialog>();
            ServiceLocator.Instance.Register<IDataStore<Item>, MockDataStore>();
        }
    }
}