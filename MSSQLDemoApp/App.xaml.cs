using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MSSQLDemoApp.Models;
using MSSQLDemoApp.ViewModels;
using MSSQLDemoApp.Views;
using MSSQLDemoApp.Store;
using MSSQLDemoApp.Services;

namespace MSSQLDemoApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly DataBase _dataBase;
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _dataBase = new DataBase();
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new RegistrationViewModel(_dataBase, new NavigationService(_navigationStore, CreateMainMenuViewModel));

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();
            base.OnStartup(e);
        }

        private MainMenuViewModel CreateMainMenuViewModel()
        {
            return new MainMenuViewModel(_dataBase);
        }
    }
}
