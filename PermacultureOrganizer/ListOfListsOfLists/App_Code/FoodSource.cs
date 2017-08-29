using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DishClass;

namespace FoodSourceClass
{
    public class FoodSource
    {
        private string name;
        private string description;
        private string imageFileName;
        private List<Dish> list = new List<Dish>();

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string ImageFileName
        {
            get { return imageFileName; }
            set { imageFileName = value; }
        }

        public List<Dish> List
        {
            get { return list; }
            set { list = value; }
        }

        public FoodSource()
        {
            Name = "q";
            Description = "";
            ImageFileName = "";
        }

        public FoodSource(string theName, string theDescription, string theImageFileName)
        {
            Name = theName;
            Description = theDescription;
            ImageFileName = theImageFileName;
        }

        public override string ToString()
        {
            return Name + " - " + Description;
        }

        public void Add(Dish item)
        {
            list.Add(item);
        }
    } // End of class FoodSource.
} // End of namespace FoodSourceClass.