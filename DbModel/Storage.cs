using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace StoreApp.DbModel
{
    public class Storage
    {
        [Key]
        public int StorageId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
