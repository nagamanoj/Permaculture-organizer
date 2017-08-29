using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DishClass
{
    public class Dish
    {
        private string name;
        private string description;
        private string imageFileName;
        // private List<Ingredients> list = new List<Ingredients>();

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

        public Dish()
        {
            Name = "";
            Description = "";
            ImageFileName = "";
        }

        public Dish(string theName, string theDescription, string theImageFileName)
        {
            Name = theName;
            Description = theDescription;
            ImageFileName = theImageFileName;
        }

        public override string ToString()
        {
            return Name;
        }

        /*
        public void Add(Ingredient item)
        {
            list.Add(item);
        }
        */
    }
}