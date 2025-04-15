using PartnerManagementApp.Data;
using PartnerManagementApp.Models;
using System.Linq;
using System.Windows;

namespace PartnerManagementApp
{
    public partial class SalesHistoryWindow : Window
    {
        private readonly AppDbContext _db = new();

        public SalesHistoryWindow(int partnerId)
        {
            InitializeComponent();
            var sales = _db.Sales.Where(s => s.PartnerId == partnerId).ToList();
            SalesGrid.ItemsSource = sales;
        }
    }
}
