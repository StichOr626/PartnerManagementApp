using PartnerManagementApp.Data;
using PartnerManagementApp.Models;
using System.Windows;
using System.Windows.Controls;

namespace PartnerManagementApp
{
    public partial class PartnerForm : Window
    {
        private readonly AppDbContext _db = new();
        private readonly int? _partnerId;

        public PartnerForm(int? partnerId = null)
        {
            InitializeComponent();
            _partnerId = partnerId;

            if (_partnerId.HasValue)
                LoadData();
        }

        private void LoadData()
        {
            var partner = _db.Partners.Find(_partnerId);
            if (partner != null)
            {
                NameBox.Text = partner.Name;
                TypeBox.Text = partner.Type;
                RatingBox.Text = partner.Rating.ToString();
                AddressBox.Text = partner.Address;
                DirectorBox.Text = partner.DirectorName;
                PhoneBox.Text = partner.Phone;
                EmailBox.Text = partner.Email;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(RatingBox.Text, out int rating) || rating < 0)
            {
                MessageBox.Show("Некорректный рейтинг", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Partner partner = _partnerId.HasValue ? _db.Partners.Find(_partnerId) : new Partner();

            partner.Name = NameBox.Text;
            partner.Type = (TypeBox.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "";
            partner.Rating = rating;
            partner.Address = AddressBox.Text;
            partner.DirectorName = DirectorBox.Text;
            partner.Phone = PhoneBox.Text;
            partner.Email = EmailBox.Text;

            if (_partnerId == null)
                _db.Partners.Add(partner);

            _db.SaveChanges();
            DialogResult = true;
        }
    }
}