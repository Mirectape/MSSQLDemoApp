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
    /// Interaction logic for AllView.xaml
    /// </summary>
    public partial class AllView : Window
    {
        public AllView(DataBase dataBase)
        {
            InitializeComponent();

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter();

            var sql = @"SELECT 
Workers.id as 'ID',
Workers.firstName as 'First Name',
Workers.secondName  as 'Second Name',
Workers.email  as 'email',
ProductsOrdered.productCode as 'Product Code'
ProductsOrdered.nameOfProduct as 'Name of product'
FROM  Workers, ProductsOrdered
WHERE Workers.email = ProductsOrdered.email
Order By Workers.Id";

            da.SelectCommand = new SqlCommand(sql, dataBase.GetConnection());
            da.Fill(dt);

            gridAllView.DataContext = dt.DefaultView;
        }
    }
}
