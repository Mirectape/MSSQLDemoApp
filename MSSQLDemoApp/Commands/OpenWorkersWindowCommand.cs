using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSQLDemoApp.Services;
using MSSQLDemoApp.ViewModels;
using MSSQLDemoApp.Models;

namespace MSSQLDemoApp.Commands
{
    class OpenWorkersWindowCommand : CommandBase
    {
        private readonly DataBase _dataBase;

        public OpenWorkersWindowCommand(DataBase dataBase)
        {
            _dataBase = dataBase;
        }

        public override void Execute(object parameter)
        {
            WorkersWindow workersWindow = new WorkersWindow(_dataBase);
            workersWindow.ShowDialog();
        }
    }
}
