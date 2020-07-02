using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    public enum Category
    {
        Assepted,
        OnStore,
        Sold
    }
    public class Item
    {
        public int ItemId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public DateTime MovingToCategoryDate { get; set; }
        public Category Category { get; set; }

    }
}
