using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermacultureOrganizer.Models
{
    public class BreedModel
    {
        public BreedModel()
        {
            BreedID = new int();
            LiveStockID = new int();
            Name = string.Empty;
            Count = new int();
        }

        public int BreedID;
        public int LiveStockID;
        public string Name;
        public int Count;
    }
}