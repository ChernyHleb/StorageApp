using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApp.DbModel;

namespace StoreApp.Services
{
    class GenericCRUD<T> where T : DbModel.DbObject
    {
        private DbModel.CodeFirstContext _context;

        public GenericCRUD(CodeFirstContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
    }
}
