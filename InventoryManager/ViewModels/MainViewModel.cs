using Caliburn.Micro;
using InventoryManager.Models;
using InventoryManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace InventoryManager.ViewModels
{
    partial class MainViewModel : Screen
    {
        private readonly string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=FoodInventory;Integrated Security=True";

        public BindableCollection<ProductModel> Products { get; set; } = new BindableCollection<ProductModel>();
        public BindableCollection<ProdCategoryModel> ProdCategories { get; set; } = new BindableCollection<ProdCategoryModel>();
        public BindableCollection<LocationModel> Locations { get; set; } = new BindableCollection<LocationModel>();
        public BindableCollection<LocationCategoryModel> LocationCategories { get; set; } = new BindableCollection<LocationCategoryModel>();
        public BindableCollection<UnitModel> Units { get; set; } = new BindableCollection<UnitModel>();
        public BindableCollection<ProductModelAllTablesMerged> ProductsAllTablesMerged { get; set; } = new BindableCollection<ProductModelAllTablesMerged>();
        
        ProductCommands productCommands;
        ProductModel updateProductRow;
        
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

                UpdateAppStatus($"Database tables fetched.", Brushes.DarkGreen);
            }
            catch (Exception ex) { UpdateAppStatus($"Error on retrieving tables from SQL database:\n{ex.Message}", Brushes.Red); }
            
            GenerateTableProductsToDisplay();
            InitializeAllPropertyFields();            
        }

        public void GenerateTableProductsToDisplay()
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
                    Description = product.Description,
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
                                
                productModelAllTablesMerged.ColorSet = ColorDataBestBeforeColumn(productModelAllTablesMerged);
                
                ProductsAllTablesMerged.Add(productModelAllTablesMerged);
                //ToDo: notifyproperty? Is the gridview refreshed really? Test it!
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
                _selectedDescription = value.Description;
                _selectedGetInDate = value.GetInDate;
                _selectedBestBefore = value.BestBefore;
                _selectedQuantity = value.Quantity;

                NotifyAllPropertyFields();

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

        //TEXTBOX Description
        string _selectedDescription;
        public string SelectedDescription
        {
            get { return _selectedDescription; }
            set { _selectedDescription = value; }
        }


        //COMBOBOX ProdCategoryName
        private ProdCategoryModel _selectedProdCategory;
        public ProdCategoryModel SelectedProdCategory
        {
            get
            {
                var dictProdCategories = ProdCategories.ToDictionary(x => x.ProdCategoryId);
                return dictProdCategories[SelectedInventoryRow.ProdCategoryId];
            }
            set { _selectedProdCategory = value; 
                NotifyOfPropertyChange(() => SelectedProdCategory);
            }
        }

        //COMBOBOX LocationName
        private LocationModel _selectedLocation;
        public LocationModel SelectedLocation
        {
            get {
                var dictLocations = Locations.ToDictionary(x => x.LocationId);
                return dictLocations[SelectedInventoryRow.LocationId];
            }
            set {
                _selectedLocation = value;
                NotifyOfPropertyChange(() => SelectedLocation);
            }
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

        //Validated TEXTBOX Quantity
        private float _selectedQuantity;
        public float SelectedQuantity
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
            set {
                _selectedUnit = value;
                NotifyOfPropertyChange(() => SelectedUnit);
            }
        }

        private string _appStatus;
        public string AppStatus
        {
            get { return _appStatus; }
            set { _appStatus = value; }
        }

        private Brush _statusColor = Brushes.Black;
        public Brush StatusColor
        {
            get { return _statusColor; }
            set
            {
                _statusColor = value;
                NotifyOfPropertyChange(() => StatusColor);
            }
        }

        private void UpdateAppStatus(string message, Brush statusColor)
        {
            StatusColor = statusColor;
            NotifyOfPropertyChange(() => StatusColor);
            AppStatus = message;
            NotifyOfPropertyChange(() => AppStatus);            
        }

        /// <summary>
        /// This method updates or inserts a row to the database.
        /// </summary>
        public void UpdateItem()
        {
            if (SelectedInventoryRow != null || createItem)
            {
                updateProductRow = new ProductModel();

                //ProductId must be set to a value which is not in the Product table in the SQL database. SQL stored proc will then Insert, not Update Table
                if (createItem) updateProductRow.ProductId = 0;
                else updateProductRow.ProductId = SelectedInventoryRow.ProductId;                

                updateProductRow.ProductName = SelectedProductName;

                updateProductRow.Description = SelectedDescription;

                if (_selectedProdCategory == null) updateProductRow.ProdCategoryId = SelectedProdCategory.ProdCategoryId; //There's nothing manually selected in combobox
                else updateProductRow.ProdCategoryId = _selectedProdCategory.ProdCategoryId;

                if (_selectedLocation == null) updateProductRow.LocationId = SelectedLocation.LocationId; //There's nothing manually selected in combobox
                else updateProductRow.LocationId = _selectedLocation.LocationId;

                updateProductRow.GetInDate = _selectedGetInDate;
                updateProductRow.BestBefore = _selectedBestBefore;
                updateProductRow.Quantity = _selectedQuantity;

                if (_selectedUnit == null) updateProductRow.UnitId = SelectedUnit.UnitId; //There's nothing manually selected in combobox
                else updateProductRow.UnitId = _selectedUnit.UnitId;

                try { productCommands.UpSertItem(updateProductRow); }
                catch (Exception ex) { UpdateAppStatus($"Unsuccessful update!\n{ex}", Brushes.Red); }
                
                ReadTableFromDatabaseAfterModification($"Update or new item creation successful. Updated table reloaded.", "Error on retrieving table \"Product\" from SQL database:\n");
                InitializeAllPropertyFields();
                NotifyAllPropertyFields();
            }
            else
            {
                UpdateAppStatus("No record was selected for updating.", Brushes.Red);
            }
            createItem = false;            
        }

        private bool createItem = false;
        public void CreateItem()
        {
            bool areFieldsFilled = SelectedInventoryRow != null ||
                                   SelectedProductName != string.Empty &&
                                   //Description can be null in database
                                   _selectedProdCategory != null &&
                                   _selectedLocation != null &&
                                   _selectedQuantity != 0 &&
                                   _selectedUnit != null;
            if (areFieldsFilled)
            {
                createItem = true;
                UpdateItem();
            }
            else UpdateAppStatus($"Not all fields have value to create a new record.", Brushes.Red);
        }

        private void NotifyAllPropertyFields()
        {
            NotifyOfPropertyChange(() => SelectedProductName);
            NotifyOfPropertyChange(() => SelectedDescription);
            NotifyOfPropertyChange(() => SelectedProdCategory);
            NotifyOfPropertyChange(() => SelectedLocation);
            NotifyOfPropertyChange(() => SelectedGetInDate);
            NotifyOfPropertyChange(() => SelectedBestBefore);
            NotifyOfPropertyChange(() => SelectedQuantity);
            NotifyOfPropertyChange(() => SelectedUnit);
        }

        private void InitializeAllPropertyFields()
        {
            _selectedProductName = string.Empty;
            _selectedDescription = "-";
            _selectedProdCategory = null;
            _selectedLocation = null;
            _selectedGetInDate = DateTime.Now;
            _selectedBestBefore = DateTime.Now + TimeSpan.FromDays(14);
            _selectedQuantity = 0;
            _selectedUnit = null;
        }

        private void ReadTableFromDatabaseAfterModification(string successMessage, string failureMessage)
        {
            try
            {
                ProductsAllTablesMerged.Clear();
                Products.Clear();
                Products.AddRange(productCommands.GetList());
                GenerateTableProductsToDisplay();                
                UpdateAppStatus(successMessage, Brushes.DarkGreen);
            }
            catch (Exception ex)
            {                
                UpdateAppStatus(failureMessage + ex.Message, Brushes.Red);
            }
        }

        public void DeleteItem()
        {
            if (SelectedInventoryRow != null)
            {
                productCommands.DeleteItem(SelectedInventoryRow.ProductId);
                ReadTableFromDatabaseAfterModification("Delete was successful. Updated table reloaded.", "Error on retrieving table \"Product\" from SQL database:\n");
            }
            else
            {
                UpdateAppStatus("No record was selected for deleting.", Brushes.Red);
            }
        }

        public void RefreshTable()
        {
            ReadTableFromDatabaseAfterModification("Refreshing table was successful. Table reloaded.", "Error on retrieving table \"Product\" from SQL database:\n");
        }

        public void EmptyTable()
        {            
            if (MessageBox.Show("All the data in the Table will be deleted. Are you sure to go continue?", "Emptying Table", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                productCommands.EmptyTable();
                ReadTableFromDatabaseAfterModification("Deleting all data was successful. The empty table reloaded.", "Error on retrieving table \"Product\" from SQL database:\n");
            }
        }

        
        public void SendMail()
        {
            //EmailSender emailSender = new EmailSender();
            //emailSender.Send("TESZT");
            Send();
        }
    }
 }

