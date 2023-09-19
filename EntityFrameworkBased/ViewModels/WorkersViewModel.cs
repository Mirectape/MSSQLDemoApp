using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace EntityFrameworkBased.ViewModels
{
    public class WorkersViewModel: ViewModelBase
    {
        private WorkersDBEntities _db;
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
                _db.SaveChanges();
            }
        }

        public WorkersViewModel()
        {
            _db = new WorkersDBEntities();
            _db.Workers.Load();
            Workers = _db.Workers.Local.ToBindingList();
        }
    }
}
