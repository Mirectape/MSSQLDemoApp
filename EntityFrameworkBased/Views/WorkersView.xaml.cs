using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EntityFrameworkBased.Views
{
    /// <summary>
    /// Interaction logic for WorkersView.xaml
    /// </summary>
    public partial class WorkersView : UserControl
    {
        private WorkersDBEntities1 _db;

        public WorkersView()
        {
            InitializeComponent();
            _db = new WorkersDBEntities1();
            LoadData(); 
        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            AddWorker addWorker = new AddWorker(this);
            
            addWorker.ShowDialog();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            EditWorker editWorker = new EditWorker(this, (Workers)gridView.SelectedItem);

            editWorker.ShowDialog();
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (gridView.SelectedItem as Workers).id;
            var deleteWorker = _db.Workers.Where(m => m.id == id).Single();
            _db.Workers.Remove(deleteWorker);
            _db.SaveChanges();
            gridView.ItemsSource = _db.Workers.ToList();
        }

        private void LoadData()
        {
            gridView.ItemsSource = _db.Workers.ToList();
        }

    }
}
