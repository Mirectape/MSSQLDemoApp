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
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        private WorkersDBEntities1 _db;

        public Orders()
        {
            InitializeComponent();

            _db = new WorkersDBEntities1();

            var req = _db.Workers.Join(_db.ProductsOrdered,
                worker => worker.email,
                products => products.email,
                (worker, products) => new
                {
                    worker.id,
                    worker.firstName,
                    worker.secondName,
                    worker.email,
                    products.productCode,
                    products.nameofProduct
                }
                );
            gridAllView.ItemsSource = req.ToList();
        }
    }
}
