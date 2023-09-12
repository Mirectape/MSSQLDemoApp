using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using MSSQLDemoApp.Models;
using MSSQLDemoApp.Commands;
using MSSQLDemoApp.Services;

namespace MSSQLDemoApp.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {
        public ICommand OpenWorkersWindowCommand { get; }

        public MainMenuViewModel(DataBase dataBase)
        {
            OpenWorkersWindowCommand = new OpenWorkersWindowCommand(dataBase);
        }
    }
}
