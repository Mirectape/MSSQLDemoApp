using EntityFrameworkBased.Services;
using EntityFrameworkBased.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EntityFrameworkBased.Commands
{
    class EnterAccountCommand : CommandBase
    {
        private WorkersDBEntities _db;
        private readonly NavigationService _navigationService;
        private readonly RegistrationViewModel _registrationViewModel;

        public EnterAccountCommand(NavigationService navigationService, RegistrationViewModel registrationViewModel)
        {
            _navigationService = navigationService;
            _registrationViewModel = registrationViewModel;
            _db = new WorkersDBEntities();
        }

        public override void Execute(object parameter)
        {
            var loginUser = _registrationViewModel.Login;
            var passUser = _registrationViewModel.Password;

            var res = _db.register.Where(e => e.login_user == loginUser && e.password_user == passUser).ToList();

            if(res.Count != 0)
            {
                _navigationService.Navigate();
            }
            else
            {
                MessageBox.Show("This account doesn't exist", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
