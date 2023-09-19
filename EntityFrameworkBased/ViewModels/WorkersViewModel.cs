using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using EntityFrameworkBased.Commands;

namespace EntityFrameworkBased.ViewModels
{
    public class WorkersViewModel: ViewModelBase
    {
        public WorkersDBEntities Db { get; }
        private Workers _selectedItem;
        private object _selectedValue;

        public BindingList<Workers> Workers { get; }
        public Workers SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        public object SelectedValue
        {
            get
            {
                return _selectedValue;
            }
            set
            {
                _selectedValue = value;
                OnPropertyChanged(nameof(SelectedValue));
            }
        }

        public ICommand SaveChangesCommand { get; }

        public WorkersViewModel()
        {
            Db = new WorkersDBEntities();
            Db.Workers.Load();
            Workers = Db.Workers.Local.ToBindingList();
            SaveChangesCommand = new SaveChangesCommand(this);
        }
    }
}
