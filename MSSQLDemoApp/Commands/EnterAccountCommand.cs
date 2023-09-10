using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using MSSQLDemoApp.Services;
using MSSQLDemoApp.ViewModels;
using System.Windows;

namespace MSSQLDemoApp.Commands
{
    class EnterAccountCommand : CommandBase
    {
        private readonly NavigationService _navigationService;
        private readonly RegistrationViewModel _registrationViewModel;

        public EnterAccountCommand(NavigationService navigationService, RegistrationViewModel registrationViewModel)
        {
            _navigationService = navigationService;
            _registrationViewModel = registrationViewModel;
        }

        public override void Execute(object parameter)
        {
            var loginUser = _registrationViewModel.Login;
            var passUser = _registrationViewModel.Password;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(queryString, _registrationViewModel.DataBase.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count == 1)
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
