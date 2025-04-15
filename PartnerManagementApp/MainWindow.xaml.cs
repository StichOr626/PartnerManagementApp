using PartnerManagementApp.Data;
using PartnerManagementApp.Models;
using PartnerManagementApp.Utils;
using System.Linq;
using System.Windows;

namespace PartnerManagementApp
{
    public partial class MainWindow : Window
    {
        private readonly AppDbContext _db = new();

        public MainWindow()
        {
            InitializeComponent();
            AutoSeeder.Seed(_db); // <--- здесь
            LoadPartners();
        }


        private void LoadPartners()
        {
            var partners = _db.Partners.ToList();

            foreach (var p in partners)
            {
                var totalQuantity = _db.Sales
                    .Where(s => s.PartnerId == p.Id)
                    .Sum(s => (decimal)s.Quantity);

                p.Discount = MaterialCalculator.CalculateDiscount(totalQuantity); // временно добавим Discount в Partner
            }

            PartnerGrid.ItemsSource = partners;
        }


        private void AddPartner_Click(object sender, RoutedEventArgs e)
        {
            var form = new PartnerForm();
            if (form.ShowDialog() == true)
                LoadPartners();
        }

        private void PartnerGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (PartnerGrid.SelectedItem is Partner selected)
            {
                var form = new PartnerForm(selected.Id);
                if (form.ShowDialog() == true)
                    LoadPartners();
            }
        }
        private void ViewSales_Click(object sender, RoutedEventArgs e)
        {
            if (PartnerGrid.SelectedItem is Partner selected)
            {
                var historyWindow = new SalesHistoryWindow(selected.Id);
                historyWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите партнера для просмотра истории", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void EditPartner_Click(object sender, RoutedEventArgs e)
        {
            if (PartnerGrid.SelectedItem is Partner selected)
            {
                var form = new PartnerForm(selected.Id);
                if (form.ShowDialog() == true)
                    LoadPartners();
            }
            else
            {
                MessageBox.Show("Выберите партнера для редактирования", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeletePartner_Click(object sender, RoutedEventArgs e)
        {
            if (PartnerGrid.SelectedItem is Partner selected)
            {
                var result = MessageBox.Show($"Удалить партнёра {selected.Name}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _db.Partners.Remove(_db.Partners.Find(selected.Id));
                    _db.SaveChanges();
                    LoadPartners();
                }
            }
            else
            {
                MessageBox.Show("Выберите партнера для удаления", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}