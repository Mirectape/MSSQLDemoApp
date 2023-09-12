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
    public class MainMenuViewModel : ViewModelBase
    {
        public DataBase DataBase { get; }

        public MainMenuViewModel(DataBase dataBase)
        {
            DataBase = dataBase;
        }
    }
}
