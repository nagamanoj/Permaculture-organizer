using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermacultureOrganizer.Models
{
    public class LiveStockModel
    {
        public LiveStockModel()
        {
            LiveStockID = new int();
            Count = new int();
            FoodPerAnimal = new int();
            Description = string.Empty;
            DietType = string.Empty;
        }

        public int LiveStockID { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public string DietType { get; set; }
        public int FoodPerAnimal { get; set; }
    }
}