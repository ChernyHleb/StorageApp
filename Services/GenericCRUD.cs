using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using StoreApp.DbModel;

namespace StoreApp.Services
{
    /// <summary>
    /// this class implements crud operations with DbContext 
    /// and notifies if some changes were applied
    /// </summary>
    class GenericCRUD<T> : INotifyPropertyChanged where T : DbModel.DbObject
    {
        private DbModel.CodeFirstContext _context;

        public GenericCRUD(CodeFirstContext context)
        {
            _context = context;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();

            OnPropertyChanged("EntityCreated");
        }

        public List<T> Read()
        {
            List<T> entities = _context.Set<T>().ToList<T>();
            return entities;
        }

        //public void Delete(int id)
        //{
            
        //}
    }
}
