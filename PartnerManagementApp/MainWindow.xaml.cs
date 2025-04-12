using PartnerManagementApp.Data;
using PartnerManagementApp.Models;
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
            LoadPartners();
        }

        private void LoadPartners()
        {
            using (var context = new AppDbContext())
            {
                PartnerGrid.ItemsSource = context.Partners.ToList();
            }
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
    }
}