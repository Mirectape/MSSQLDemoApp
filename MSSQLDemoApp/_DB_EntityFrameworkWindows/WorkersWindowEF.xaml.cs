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
using System.Data.Entity;
using System.Data;

namespace MSSQLDemoApp._DB_EntityFrameworkWindows
{
    /// <summary>
    /// Interaction logic for WorkersWindowEF.xaml
    /// </summary>
    public partial class WorkersWindowEF : Window
    {

        private WorkersDBEntities1 _db;

        private DataRowView _selectedWorker;

        public WorkersWindowEF()
        {
            InitializeComponent();
            _db = new WorkersDBEntities1();
            _db.Workers.Load();
            gridView.DataContext = _db.Workers.Local.ToBindingList<Workers>();
        }
        public void GVCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            _selectedWorker = (DataRowView)gridView.SelectedItem;
            _selectedWorker.BeginEdit();
        }

        private void GVCurrentCellChanged(object sender, EventArgs e)
        {
            if (_selectedWorker == null) return;
            _selectedWorker.EndEdit();
            _db.SaveChanges();
        }

        private void MenuItemDeleteClick(object sender, RoutedEventArgs e)
        {
            _selectedWorker = (DataRowView)gridView.SelectedItem;
            _selectedWorker.Row.Delete();
            _db.SaveChanges();
        }

        private void MenuItemAddClick(object sender, RoutedEventArgs e)
        {
            Workers newWorker = new Workers();
            AddWindowEF add = new AddWindowEF(newWorker);
            add.ShowDialog();


            if (add.DialogResult.Value)
            {
                _db.Workers.Add(newWorker);
                _db.SaveChanges();
            }
        }

        private void AllViewShow(object sender, RoutedEventArgs e)
        {
            //new AllView(_dataBase).ShowDialog();
        }
    }
}
