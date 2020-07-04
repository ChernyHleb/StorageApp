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

        public List<T> Read()
        {
            List<T> entities = _context.Set<T>().ToList<T>();
            return entities;
        }

        // BAD UPDATE, REMAKE!

        //public void Update(T entity)
        //{   

        //    if (entity.GetType().Equals(typeof(Item)))
        //    {
                
        //        int entID = (entity as Item).ItemId;
        //        Item OldEntity = _context.Set<Item>().FirstOrDefault(e => e.ItemId == entID);
        //        _context.Set<Item>().Remove(OldEntity);
        //        _context.Set<Item>().Add(entity as Item);
        //        //OldEntity = entity as Item;
        //        _context.SaveChanges();
        //        Console.WriteLine("@@@@@@@@@@@@@@111");
        //    }
        //    else if (entity.GetType().Equals(typeof(Category)))
        //    {
        //        throw new Exception("kek");
        //    }
        //    else if (entity.GetType().Equals(typeof(Storage)))
        //    {
        //        throw new Exception("kek");
        //    }
        //}

        //public void Delete(int id)
        //{
            
        //}
    }
}
