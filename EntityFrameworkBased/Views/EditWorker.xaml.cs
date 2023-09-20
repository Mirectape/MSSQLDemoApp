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
    /// Interaction logic for EditWorker.xaml
    /// </summary>
    public partial class EditWorker : Window
    {
        private WorkersDBEntities1 _db; 
        private Workers _workerToChange;
        private WorkersView workersView1;

        public EditWorker(WorkersView workersView, Workers worker)
        {
            InitializeComponent();
            _db = new WorkersDBEntities1();
            _workerToChange = (from m in _db.Workers
                               where m.id == worker.id
                               select m).Single();
            workersView1 = workersView;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (comboBox.Text)
                {
                    case "First Name":
                        _workerToChange.firstName = txtBox.Text;
                        break;
                    case "Second Name":
                        _workerToChange.secondName = txtBox.Text;
                        break;
                    case "Paternal Name":
                        _workerToChange.paternalName = txtBox.Text;
                        break;
                    case "Phone Number":
                        _workerToChange.phoneNumber = Convert.ToInt32(txtBox.Text);
                        break;
                    case "Email":
                        _workerToChange.email = txtBox.Text;
                        break;
                    default:
                        break;
                }
                _db.SaveChanges();
                workersView1.gridView.ItemsSource = _db.Workers.ToList();
                this.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Check the correctness of all values", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
