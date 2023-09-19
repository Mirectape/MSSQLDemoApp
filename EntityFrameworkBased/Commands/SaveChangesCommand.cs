using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkBased.ViewModels;

namespace EntityFrameworkBased.Commands
{
    class SaveChangesCommand : CommandBase
    {
        private WorkersDBEntities _db;
        public SaveChangesCommand(WorkersViewModel workersViewModel)
        {
            _db = workersViewModel.Db;
        }

        public override void Execute(object parameter)
        {
            _db.SaveChanges();
        }
    }
}
