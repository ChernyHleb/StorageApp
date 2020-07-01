using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StoreApp.DbModel
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public DateTime MovingToCategoryDate { get; set; }

        /// FOREIGN KEYS
        /// 1 - Assepted 2 - On Store 3 - Sold
        public int CategoryId { get; set; }
        public int StorageId { get; set; }
        
        
        /// REFERENCES:
        public virtual Category Category { get; set; }
        public virtual Storage Storage { get; set; }
    }
}
