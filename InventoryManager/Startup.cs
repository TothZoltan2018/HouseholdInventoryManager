using Caliburn.Micro;
using InventoryManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InventoryManager
{
    class Startup : BootstrapperBase
    {
        public Startup()
        {
            Initialize();           
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
