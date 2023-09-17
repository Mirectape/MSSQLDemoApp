using MSSQLDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace MSSQLDemoApp
{
    /// <summary>
    /// Interaction logic for WorkersWindow.xaml
    /// </summary>
    public partial class WorkersWindow : Window
    {
        private DataBase _dataBase;
        private DataView _dataView;

        private SqlDataAdapter _dataAdapter;
        private DataTable _dataTable;

        private DataRowView _selectedWorker;
        public WorkersWindow(DataBase dataBase)
        {
            InitializeComponent();
            _dataBase = dataBase;
            _dataAdapter = new SqlDataAdapter();
            _dataTable = new DataTable();
            SetSelectionParameters();
            SetInsertParameters();
            SetUpdateParameters();
            SetDeleteParameters();
            _dataAdapter.Fill(_dataTable);
            _dataView = _dataTable.DefaultView;
            gridView.DataContext = _dataTable.DefaultView;
        }

        private void SetSelectionParameters()
        {
            var sql = @"SELECT * FROM Workers Order By Workers.Id";
            _dataAdapter.SelectCommand = new SqlCommand(sql, _dataBase.GetConnection());
        }

        private void SetInsertParameters()
        {
            var sql = @"INSERT INTO Workers (firstName,  secondName,  paternalName, phoneNumber, email) 
                                 VALUES (@firstName, @secondName, @paternalName, @phoneNumber, @email); 
                     SET @id = @@IDENTITY;";

            _dataAdapter.InsertCommand = new SqlCommand(sql, _dataBase.GetConnection());
            _dataAdapter.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").Direction = ParameterDirection.Output;
            _dataAdapter.InsertCommand.Parameters.Add("@firstName", SqlDbType.VarChar, 50, "firstName");
            _dataAdapter.InsertCommand.Parameters.Add("@secondName", SqlDbType.VarChar, 50, "secondName");
            _dataAdapter.InsertCommand.Parameters.Add("@paternalName", SqlDbType.VarChar, 50, "paternalName");
            _dataAdapter.InsertCommand.Parameters.Add("@phoneNumber", SqlDbType.Int, 20, "phoneNumber");
            _dataAdapter.InsertCommand.Parameters.Add("@email", SqlDbType.VarChar, 50, "email");
        }

        private void SetUpdateParameters()
        {
            var sql = @"UPDATE Workers SET 
                           firstName = @firstName,
                           secondName = @secondName, 
                           paternalName = @paternalName,
                           phoneNumber = @phoneNumber,
                           email = @email
                    WHERE id = @id";

            _dataAdapter.UpdateCommand = new SqlCommand(sql, _dataBase.GetConnection());
            _dataAdapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id").SourceVersion = DataRowVersion.Original;
            _dataAdapter.UpdateCommand.Parameters.Add("@firstName", SqlDbType.VarChar, 50, "firstName");
            _dataAdapter.UpdateCommand.Parameters.Add("@secondName", SqlDbType.VarChar, 50, "secondName");
            _dataAdapter.UpdateCommand.Parameters.Add("@paternalName", SqlDbType.VarChar, 50, "paternalName");
            _dataAdapter.UpdateCommand.Parameters.Add("@phoneNumber", SqlDbType.Int, 20, "phoneNumber");
            _dataAdapter.UpdateCommand.Parameters.Add("@email", SqlDbType.VarChar, 50, "email");
        }

        private void SetDeleteParameters()
        {
            var sql = "DELETE FROM Workers WHERE id = @id";
            _dataAdapter.DeleteCommand = new SqlCommand(sql, _dataBase.GetConnection());
            _dataAdapter.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id");
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
            _dataAdapter.Update(_dataTable);
        }

        private void MenuItemDeleteClick(object sender, RoutedEventArgs e)
        {
            _selectedWorker = (DataRowView)gridView.SelectedItem;
            _selectedWorker.Row.Delete();
            _dataAdapter.Update(_dataTable);
        }

        private void MenuItemAddClick(object sender, RoutedEventArgs e)
        {
            DataRow newWorker = _dataTable.NewRow();
            AddWindow add = new AddWindow(newWorker);
            add.ShowDialog();


            if (add.DialogResult.Value)
            {
                _dataTable.Rows.Add(newWorker);
                _dataAdapter.Update(_dataTable);
            }
        }

        private void AllViewShow(object sender, RoutedEventArgs e)
        {
            new AllView(_dataBase).ShowDialog();
        }
    }
}
