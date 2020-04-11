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

        ProductCommands productCommands;
        private System.Windows.Media.Brush _statusColor = System.Windows.Media.Brushes.Black;

        public MainViewModel()
        {
            try
            {
                productCommands = new ProductCommands(_connectionString);
                Products.AddRange(productCommands.GetList());

                ProdCategoryCommands prodCategoryCommands = new ProdCategoryCommands(_connectionString);
                ProdCategories.AddRange(prodCategoryCommands.GetList());

                LocationCommands locationCommands = new LocationCommands(_connectionString);
                Locations.AddRange(locationCommands.GetList());

                LocCategoryCommands locCategoryCommands = new LocCategoryCommands(_connectionString);
                LocationCategories.AddRange(locCategoryCommands.GetList());

                UnitCommands unitCommands = new UnitCommands(_connectionString);
                Units.AddRange(unitCommands.GetList());

                StatusColor = System.Windows.Media.Brushes.DarkGreen;
                UpdateAppStatus($"Database tables fetched.");
            }
            catch (Exception ex)
            {
                StatusColor = System.Windows.Media.Brushes.Red;
                UpdateAppStatus($"Error on retrieving tables from SQL database:\n{ex.Message}");
            }
                                   
            GenerateTableProductsToDisplay();
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
            get { return _selectedInventoryRow; }
            set
            {
                _selectedInventoryRow = value;

                _selectedProductName = value.ProductName;
                _selectedGetInDate = value.GetInDate;
                _selectedBestBefore = value.BestBefore;
                _selectedQuantity = value.Quantity;

                NotifyOfPropertyChange(() => SelectedProductName);   
                NotifyOfPropertyChange(() => SelectedProdCategory);
                NotifyOfPropertyChange(() => SelectedLocation);
                NotifyOfPropertyChange(() => SelectedGetInDate);
                NotifyOfPropertyChange(() => SelectedBestBefore);
                NotifyOfPropertyChange(() => SelectedQuantity);
                NotifyOfPropertyChange(() => SelectedUnit);

                NotifyOfPropertyChange(() => SelectedInventoryRow);
            }
        }

        //TEXTBOX ProductName
        string _selectedProductName;
        public string SelectedProductName
        {            
            get { return _selectedProductName; }
            set { _selectedProductName = value; }
        }

        //COMBOBOX ProdCategoryName
        private ProdCategoryModel _selectedProdCategory;
        public ProdCategoryModel SelectedProdCategory
        {
            get
            {
                var dictProdCategories = ProdCategories.ToDictionary(x => x.ProdCategoryId);
                return dictProdCategories[SelectedInventoryRow.ProdCategoryId];

                //The below 4 commented out lines are two not woking solutions. Why?
                // _selectedProdCategory = new ProdCategoryModel { ProdCategoryId = SelectedInventoryRow.ProdCategoryId, ProdCatName = SelectedInventoryRow.ProdCatName };

                //_selectedProdCategory.ProdCategoryId = _selectedInventoryRow.ProdCategoryId;
                //_selectedProdCategory.ProdCatName = _selectedInventoryRow.ProdCatName;

                //return _selectedProdCategory;
            }
            set { _selectedProdCategory = value; }            
        }

        //COMBOBOX LocationName
        private LocationModel _selectedLocation;
        public LocationModel SelectedLocation
        {
            get
            {
                var dictLocations = Locations.ToDictionary(x => x.LocationId);
                return dictLocations[SelectedInventoryRow.LocationId];
            }
            set { _selectedLocation = value; }
        }

        //DATETIMEPICKER GetInDate
        private DateTime _selectedGetInDate;
        public DateTime SelectedGetInDate
        {
            get { return _selectedGetInDate; }
            set { _selectedGetInDate = value; }             
        }

        //DATETIMEPICKER BestBefore
        private DateTime _selectedBestBefore;
        public DateTime SelectedBestBefore
        {
            get { return _selectedBestBefore; }
            set { _selectedBestBefore = value; }
        }

        private int _selectedQuantity;
        public int SelectedQuantity
        {
            get { return _selectedQuantity; }
            set { _selectedQuantity = value; }
        }

        //COMBOBOX Units
        private UnitModel _selectedUnit;
        public UnitModel SelectedUnit
        {
            get
            {
                var dictUnits = Units.ToDictionary(x => x.UnitId);
                return dictUnits[SelectedInventoryRow.UnitId];
            }
            set { _selectedUnit = value; }
        }

        private string _appStatus;
        public string AppStatus
        {
            get { return _appStatus; }
            set { _appStatus = value; }        
        }

        public System.Windows.Media.Brush StatusColor
        {
            get { return _statusColor; }
            set
            {
                _statusColor = value;
                NotifyOfPropertyChange(() => StatusColor);
            }
        }

        private void UpdateAppStatus(string message)
        {
            NotifyOfPropertyChange(() => StatusColor);
            AppStatus = message;
            NotifyOfPropertyChange(() => AppStatus);
        }

        public void UpdateItem()
        {
            if (SelectedInventoryRow != null)
            {
                ProductModel updateProductRow = new ProductModel();

                updateProductRow.ProductId = SelectedInventoryRow.ProductId;
                updateProductRow.ProductName = SelectedProductName;               

                if (_selectedProdCategory == null) updateProductRow.ProdCategoryId = SelectedProdCategory.ProdCategoryId; //There's nothing manually selected in combobox
                else updateProductRow.ProdCategoryId = _selectedProdCategory.ProdCategoryId;

                if (_selectedLocation == null) updateProductRow.LocationId = SelectedLocation.LocationId; //There's nothing manually selected in combobox
                else updateProductRow.LocationId = _selectedLocation.LocationId;
                
                updateProductRow.GetInDate = _selectedGetInDate;
                updateProductRow.BestBefore = _selectedBestBefore;
                updateProductRow.Quantity = _selectedQuantity;

                if (_selectedUnit == null) updateProductRow.UnitId = SelectedUnit.UnitId; //There's nothing manually selected in combobox
                else updateProductRow.UnitId = _selectedUnit.UnitId;

                try { productCommands.UpdateItem(updateProductRow); }
                catch (Exception ex)
                {
                    StatusColor = System.Windows.Media.Brushes.Red;
                    UpdateAppStatus($"Unsuccessful update!\n{ex}"); 
                }

                try
                {
                    ProductModelAllTablesMerged.Clear();
                    Products.Clear();
                    Products.AddRange(productCommands.GetList());
                    GenerateTableProductsToDisplay();
                    StatusColor = System.Windows.Media.Brushes.DarkGreen;
                    UpdateAppStatus($"Update successful. Updated table reloaded.");
                }
                catch (Exception ex)
                {
                    StatusColor = System.Windows.Media.Brushes.Red;
                    UpdateAppStatus($"Error on retrieving table \"Product\" from SQL database:\n{ex.Message}");
                }
                
            }
                
        }

    }
 }

