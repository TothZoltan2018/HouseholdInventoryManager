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
        public BindableCollection<LocationModel> Locations { get; set; } = new BindableCollection<LocationModel>();
        public BindableCollection<LocationCategoryModel> LocationCategories { get; set; } = new BindableCollection<LocationCategoryModel>();

        public BindableCollection<ProductModelAllTablesMerged> ProductModelAllTablesMerged { get; set; } = new BindableCollection<ProductModelAllTablesMerged>();

        public MainViewModel()
        {
            try
            {
                ProductCommands productCommands = new ProductCommands(_connectionString);
                Products.AddRange(productCommands.GetList());

                ProdCategoryCommands prodCategoryCommands = new ProdCategoryCommands(_connectionString);
                ProdCategories.AddRange(prodCategoryCommands.GetList());

                LocationCommands locationCommands = new LocationCommands(_connectionString);
                Locations.AddRange(locationCommands.GetList());

                LocCategoryCommands locCategoryCommands = new LocCategoryCommands(_connectionString);
                LocationCategories.AddRange(locCategoryCommands.GetList());

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
            var locDictionary = Locations.ToDictionary(loc => loc.LocationId);
            var locCatDictionary = LocationCategories.ToDictionary(locCat => locCat.LocCategoryId); 

            foreach (var product in Products)
            {
                ProductModelAllTablesMerged productModelAllTablesMerged = new ProductModelAllTablesMerged
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProdCategoryId = product.ProdCategoryId,
                    LocationId = product.LocationId,
                    GetInDate = product.GetInDate,
                    BestBefore = product.BestBefore,
                    Quantity = product.Quantity
                };

                prodcatDictionary.TryGetValue(productModelAllTablesMerged.ProdCategoryId, out ProdCategoryModel prodcat);
                productModelAllTablesMerged.ProdCatName = prodcat.ProdCatName;

                locDictionary.TryGetValue(productModelAllTablesMerged.LocationId, out LocationModel loc);
                productModelAllTablesMerged.LocationName = loc.LocationName;

                locCatDictionary.TryGetValue(loc.LocCategoryId, out LocationCategoryModel locCat);
                productModelAllTablesMerged.LocCatName = locCat.LocCatName;

                //todo
                
                productModelAllTablesMerged.LocCatId = locCat.LocCategoryId;

                this.ProductModelAllTablesMerged.Add(productModelAllTablesMerged);
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
