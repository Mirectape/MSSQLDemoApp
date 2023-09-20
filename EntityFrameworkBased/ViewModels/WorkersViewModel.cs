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
        private Workers _selectedWorker;
        public WorkersDBEntities1 Db { get; }
        public BindingList<Workers> Workers { get; }
        public Workers SelectedWorker
        {
            get
            {
                return _selectedWorker;
            }
            set
            {
                _selectedWorker = value;
                OnPropertyChanged(nameof(_selectedWorker));
            }
        }

        public WorkersViewModel()
        {
            Db = new WorkersDBEntities1();
            Db.Workers.Load();
            Workers = Db.Workers.Local.ToBindingList();
        }
    }
}
