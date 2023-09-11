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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MSSQLDemoApp.Views
{
    /// <summary>
    /// Interaction logic for WorkersView.xaml
    /// </summary>
    public partial class WorkersView : UserControl
    {
        public WorkersView()
        {
            InitializeComponent();
            
        }

        private void GVCurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void GVCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }
    }
}
