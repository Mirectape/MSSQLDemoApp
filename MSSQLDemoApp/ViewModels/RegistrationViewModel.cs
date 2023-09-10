using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MSSQLDemoApp.Models;
using MSSQLDemoApp.Commands;
using MSSQLDemoApp.Services;

namespace MSSQLDemoApp.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        public DataBase DataBase { get; }

        private string _login;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand EnterAccountCommand { get; }

        public RegistrationViewModel(DataBase dataBase, NavigationService navigationService)
        {
            EnterAccountCommand = new EnterAccountCommand(navigationService, this);
            DataBase = dataBase;
        }
    }
}
