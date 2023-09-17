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

namespace MSSQLDemoApp._DB_EntityFrameworkWindows
{
    /// <summary>
    /// Interaction logic for AddWindowEF.xaml
    /// </summary>
    public partial class AddWindowEF : Window
    {
        public AddWindowEF()
        {
            InitializeComponent();
        }
        public AddWindowEF(Workers newWorker) : this()
        {
            cancelBtn.Click += delegate { this.DialogResult = false; };
            okBtn.Click += delegate
            {
                newWorker.firstName = txtFirstName.Text;
                newWorker.secondName = txtSecondName.Text;
                newWorker.paternalName = txtPaternalName.Text;
                newWorker.phoneNumber = int.TryParse(txtPhoneNumber.Text, out int a) ? int.Parse(txtPhoneNumber.Text) : 0;
                newWorker.email = txtEmail.Text;
                this.DialogResult = !false;
            };

        }
    }
}
