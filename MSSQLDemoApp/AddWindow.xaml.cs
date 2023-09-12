using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private AddWindow()
        {
            InitializeComponent();
        }

        public AddWindow(DataRow newWorker) : this()
        {
            cancelBtn.Click += delegate { this.DialogResult = false; };
            okBtn.Click += delegate
            {
                newWorker["firstName"] = txtFirstName.Text;
                newWorker["secondName"] = txtSecondName.Text;
                newWorker["paternalName"] = txtPaternalName.Text;
                newWorker["phoneNumber"] = txtPhoneNumber.Text;
                newWorker["email"] = txtEmail.Text;
                this.DialogResult = !false;
            };

        }
    }
}
