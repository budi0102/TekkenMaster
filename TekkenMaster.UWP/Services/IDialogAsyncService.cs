using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekkenMaster.UWP.Services
{
    public interface IDialogAsyncService
    {
        Task<bool?> ShowDialogAsync();
    }
}
