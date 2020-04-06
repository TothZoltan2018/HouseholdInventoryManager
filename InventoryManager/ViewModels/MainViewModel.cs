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
        private int _selectedProdCategoryId;

        public BindableCollection<ProductModel> Products { get; set; } = new BindableCollection<ProductModel>();
        public BindableCollection<ProdCategoryModel> ProdCategories { get; set; } = new BindableCollection<ProdCategoryModel>();
        public BindableCollection<ProductModelToDisplay> ProductsToDisplay { get; set; } = new BindableCollection<ProductModelToDisplay>();

        public MainViewModel()
        {
            try
            {
                ProductCommands productCommands = new ProductCommands(_connectionString);
                Products.AddRange(productCommands.GetList());

                ProdCategoryCommands prodCategoryCommands = new ProdCategoryCommands(_connectionString);
                ProdCategories.AddRange(prodCategoryCommands.GetList());

                //Todo: Location, locationId
            }
            catch (Exception ex)
            {

                throw; //ToDo
            }
                                   
            GenerateTableProductsToDisplay(); //ToDo Location also needs to be decoded
        }

        private void GenerateTableProductsToDisplay()
        {
            var prodcatDictionary = ProdCategories.ToDictionary(cat => cat.ProdCategoryId);
            foreach (var product in Products)
            {
                ProductModelToDisplay productModelToDisplay = new ProductModelToDisplay();

                productModelToDisplay.ProductId = product.ProductId;
                productModelToDisplay.ProductName = product.ProductName;
                productModelToDisplay.ProdCategoryId = product.ProdCategoryId;
                productModelToDisplay.LocationId = product.LocationId;
                productModelToDisplay.GetInDate = product.GetInDate;
                productModelToDisplay.BestBefore = product.BestBefore;
                productModelToDisplay.Quantity = product.Quantity;

                prodcatDictionary.TryGetValue(productModelToDisplay.ProdCategoryId, out ProdCategoryModel prodcat);
                productModelToDisplay.ProdCatName = prodcat.ProdCatName;

                ProductsToDisplay.Add(productModelToDisplay);
            }
        }



        //public int SelectedProdCategoryId
        //{
        //    get
        //    {

        //        return Products[2].ProdCategoryId;
        //    }

        //    set
        //    {
        //        _selectedProdCategoryId = value;
        //        NotifyOfPropertyChange(() => SelectedProdCategoryId);
        //    }
        //}





    }
}
