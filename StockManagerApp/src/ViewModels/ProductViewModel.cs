using System.Collections.ObjectModel;

using System.Windows.Input;
using StockManagerApp.src.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace StockManagerApp.src.ViewModels
{
    public class ProductViewModel : ObservableObject
    {

        private ObservableCollection<Product> products;
        private decimal totalPrice;

        public ObservableCollection<Product> Products
        {
            get => products;
            set => SetProperty(ref products, value);
        }
        public ProductViewModel()
        {
            // Initialize the collection with some sample data
            products = new ObservableCollection<Product>();
            AddProductData();
            CalculateTotalCommand = new Command(CalculateTotal);
        }

        public decimal TotalPrice
        {
            get => totalPrice;
            set => SetProperty(ref totalPrice, value);
        }

        public ICommand CalculateTotalCommand { get; }
        private void AddProductData()
        {
            for (int i = 0; i < 10; i++)
            {
                products.Add(new Product { ID = i, Name = $"Product {i}", Price = 19.99m + i * 10 });

            }
        }
        private void CalculateTotal()
        {
            TotalPrice = Products.Sum(product => product.Price);
        }
    }
}
