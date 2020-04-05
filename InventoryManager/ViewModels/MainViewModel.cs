using Caliburn.Micro;
using InventoryManager.Models;
using InventoryManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.ViewModels
{
    class MainViewModel : Screen
    {
        private readonly string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=FoodInventory;Integrated Security=True";

        public MainViewModel()
        {
            try
            {
                ProductCommands productCommands = new ProductCommands(_connectionString);
                Products.AddRange(productCommands.GetList());
            }
            catch (Exception ex)
            {

                throw; //ToDo
            }
        }

        public BindableCollection<ProductModel> Products { get; set; } = new BindableCollection<ProductModel>();


    }
}
