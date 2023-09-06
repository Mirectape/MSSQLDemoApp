using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSQLDemoApp.Models;

namespace MSSQLDemoApp.ViewModels
{
    public class WorkersViewModel : ViewModelBase
    {
        public DataBase DataBase { get; }

        public WorkersViewModel(DataBase dataBase)
        {
            DataBase = dataBase;
        }
    }
}
