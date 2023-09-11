using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MSSQLDemoApp.Models;

namespace MSSQLDemoApp.ViewModels
{
    public class WorkersViewModel : ViewModelBase
    {
        public DataBase DataBase { get; }
        public DataView DataView { get; }

        public SqlDataAdapter DataAdapter { get; }
        public DataTable DataTable { get; }

        public DataRowView SelectedWorker { get; }

        public WorkersViewModel(DataBase dataBase)
        {
            DataBase = dataBase;
            DataAdapter = new SqlDataAdapter();
            DataTable = new DataTable();
            SetSelectionParameters();
            SetInsertParameters();
            SetUpdateParameters();
            DataAdapter.Fill(DataTable);
            DataView = DataTable.DefaultView;
        }

        private void SetSelectionParameters()
        {
            var sql = @"SELECT * FROM Workers Order By Workers.Id";
            DataAdapter.SelectCommand = new SqlCommand(sql, DataBase.GetConnection());
        }

        private void SetInsertParameters()
        {
            var sql = @"INSERT INTO Workers (firstName,  secondName,  paternalName, phoneNumber, email) 
                                 VALUES (@firstName, @secondName, @paternalName, @phoneNumber, @email); 
                     SET @id = @@IDENTITY;";

            DataAdapter.InsertCommand = new SqlCommand(sql, DataBase.GetConnection());
            DataAdapter.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").Direction = ParameterDirection.Output;
            DataAdapter.InsertCommand.Parameters.Add("@firstName", SqlDbType.VarChar, 50, "firstName");
            DataAdapter.InsertCommand.Parameters.Add("@secondName", SqlDbType.VarChar, 50, "secondName");
            DataAdapter.InsertCommand.Parameters.Add("@paternalName", SqlDbType.VarChar, 50, "paternalName");
            DataAdapter.InsertCommand.Parameters.Add("@phoneNumber", SqlDbType.Int, 20, "phoneNumber");
            DataAdapter.InsertCommand.Parameters.Add("@email", SqlDbType.VarChar, 50, "email");
        }

        private void SetUpdateParameters()
        {
            var sql = @"UPDATE Workers SET 
                           firstName = @firstName,
                           secondName = @secondName, 
                           paternalName = @paternalName,
                           phoneNumber = @phoneNumber,
                           email = @email,
                    WHERE id = @id";

            DataAdapter.UpdateCommand = new SqlCommand(sql, DataBase.GetConnection());
            DataAdapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id").SourceVersion = DataRowVersion.Original;
            DataAdapter.UpdateCommand.Parameters.Add("@firstName", SqlDbType.VarChar, 50, "firstName");
            DataAdapter.UpdateCommand.Parameters.Add("@secondName", SqlDbType.VarChar, 50, "secondName");
            DataAdapter.UpdateCommand.Parameters.Add("@paternalName", SqlDbType.VarChar, 50, "paternalName");
            DataAdapter.UpdateCommand.Parameters.Add("@phoneNumber", SqlDbType.Int, 20, "phoneNumber");
            DataAdapter.UpdateCommand.Parameters.Add("@email", SqlDbType.VarChar, 50, "email");
        }

        private void SetDeleteParameters()
        {
            var sql = "DELETE FROM Workers WHERE id = @id";
            DataAdapter.DeleteCommand = new SqlCommand(sql, DataBase.GetConnection());
            DataAdapter.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id");
        }

        public void GVCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            SelectedWorker.BeginEdit();
            //da.Update(dt);
        }
    }
}
