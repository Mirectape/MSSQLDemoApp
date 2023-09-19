using EntityFrameworkBased.Commands;
using EntityFrameworkBased.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EntityFrameworkBased.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
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

        public RegistrationViewModel(NavigationService navigationService)
        {
            EnterAccountCommand = new EnterAccountCommand(navigationService, this);
        }
    }
}
