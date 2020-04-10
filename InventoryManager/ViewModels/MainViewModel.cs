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

        public BindableCollection<ProductModel> Products { get; set; } = new BindableCollection<ProductModel>();
        public BindableCollection<ProdCategoryModel> ProdCategories { get; set; } = new BindableCollection<ProdCategoryModel>();
        public BindableCollection<LocationModel> Locations { get; set; } = new BindableCollection<LocationModel>();
        public BindableCollection<LocationCategoryModel> LocationCategories { get; set; } = new BindableCollection<LocationCategoryModel>();
        public BindableCollection<UnitModel> Units { get; set; } = new BindableCollection<UnitModel>();
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

                UnitCommands unitCommands = new UnitCommands(_connectionString);
                Units.AddRange(unitCommands.GetList());
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
            var unitDictionary = Units.ToDictionary(u => u.UnitId);

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
                    Quantity = product.Quantity,
                    UnitId = product.UnitId
                };

                prodcatDictionary.TryGetValue(productModelAllTablesMerged.ProdCategoryId, out ProdCategoryModel prodcat);
                productModelAllTablesMerged.ProdCatName = prodcat.ProdCatName;

                locDictionary.TryGetValue(productModelAllTablesMerged.LocationId, out LocationModel loc);
                productModelAllTablesMerged.LocationName = loc.LocationName;

                locCatDictionary.TryGetValue(loc.LocCategoryId, out LocationCategoryModel locCat);
                productModelAllTablesMerged.LocCatName = locCat.LocCatName;

                productModelAllTablesMerged.LocCatId = locCat.LocCategoryId;

                unitDictionary.TryGetValue(productModelAllTablesMerged.UnitId, out UnitModel unit);
                productModelAllTablesMerged.UnitName = unit.UnitName;
                
                this.ProductModelAllTablesMerged.Add(productModelAllTablesMerged);
            }
        }

        private ProductModelAllTablesMerged _selectedInventoryRow;
        public ProductModelAllTablesMerged SelectedInventoryRow 
        {
            get
            {
                return _selectedInventoryRow;
            }
            set
            {
                _selectedInventoryRow = value;

                NotifyOfPropertyChange(() => SelectedProductName);   
                NotifyOfPropertyChange(() => SelectedProdCategoryName);
                NotifyOfPropertyChange(() => SelectedLocationName);
                NotifyOfPropertyChange(() => SelectedGetInDate);
                NotifyOfPropertyChange(() => SelectedBestBefore);
                NotifyOfPropertyChange(() => SelectedQuantity);
                NotifyOfPropertyChange(() => SelectedUnitName);

                NotifyOfPropertyChange(() => SelectedInventoryRow);
            }
        }

        //TEXTBOX ProductName
        string _selectedProductName;
        public string SelectedProductName
        {
            get { return SelectedInventoryRow.ProductName; }
            set { _selectedProductName = value; }
        }

        //COMBOBOX ProdCategoryName
        private ProdCategoryModel _selectedProdCategoryName;
        public ProdCategoryModel SelectedProdCategoryName
        {
            get
            {
                var dictProdCategories = ProdCategories.ToDictionary(x => x.ProdCategoryId);
                return dictProdCategories[SelectedInventoryRow.ProdCategoryId];

                //The below 4 commented out lines are two not woking solutions. Why?
                // _selectedProdCategoryName = new ProdCategoryModel { ProdCategoryId = SelectedInventoryRow.ProdCategoryId, ProdCatName = SelectedInventoryRow.ProdCatName };

                //_selectedProdCategoryName.ProdCategoryId = _selectedInventoryRow.ProdCategoryId;
                //_selectedProdCategoryName.ProdCatName = _selectedInventoryRow.ProdCatName;

                //return _selectedProdCategory;
            }
            set
            {
                _selectedProdCategoryName = value;
            }
        }

        //COMBOBOX LocationName
        private LocationModel _selectedLocationName;
        public LocationModel SelectedLocationName
        {
            get
            {
                var dictLocations = Locations.ToDictionary(x => x.LocationId);
                return dictLocations[SelectedInventoryRow.LocationId];
            }
            set
            {
                _selectedLocationName = value;
            }
        }

        //DATETIMEPICKER GetInDate
        private DateTime _selectedGetInDate;
        public DateTime SelectedGetInDate
        {
            get { return SelectedInventoryRow.GetInDate; }
            set { _selectedGetInDate = value; }             
        }

        //DATETIMEPICKER BestBefore
        private DateTime _selectedBestBefore;
        public DateTime SelectedBestBefore
        {
            get { return SelectedInventoryRow.BestBefore; }
            set { _selectedBestBefore = value; }
        }

        private int _selectedQuantity;
        public int SelectedQuantity
        {
            get { return SelectedInventoryRow.Quantity; }
            set { _selectedQuantity = value; }
        }

        //COMBOBOX Units
        private UnitModel _selectedUnitName;
        public UnitModel SelectedUnitName
        {
            get
            {
                var dictUnits = Units.ToDictionary(x => x.UnitId);
                return dictUnits[SelectedInventoryRow.UnitId];
            }
            set
            {
                _selectedUnitName = value;
            }
        }
    }
}
