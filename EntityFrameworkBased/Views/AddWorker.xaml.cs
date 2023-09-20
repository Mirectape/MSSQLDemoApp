using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EntityFrameworkBased.Views
{
    /// <summary>
    /// Interaction logic for AddWorker.xaml
    /// </summary>
    public partial class AddWorker : Window
    {
        private WorkersDBEntities1 _db = new WorkersDBEntities1();
        private WorkersView workersView1;

        public AddWorker(WorkersView workersView)
        {
            InitializeComponent();
            workersView1 = workersView;
        }

        private void okBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Workers worker = new Workers()
                {
                    id = _db.Workers.ToArray().LastOrDefault().id + 1,
                    firstName = txtFirstName.Text,
                    secondName = txtSecondName.Text,
                    paternalName = txtPaternalName.Text,
                    phoneNumber = Convert.ToInt32(txtPhoneNumber.Text),
                    email = txtEmail.Text
                };
                _db.Workers.Add(worker);
                _db.SaveChanges();
                workersView1.gridView.ItemsSource = _db.Workers.ToList();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Check the correctness of all values", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
