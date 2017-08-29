using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FoodSourceClass;

namespace FoodGroupClass
{
    public class FoodGroup
    {
        private string name;
        private string description;
        private string imageFileName;
        private List<FoodSource> list = new List<FoodSource>();

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

        public List<FoodSource> List
        {
            get { return list; }
            set { list = value; }
        }

        public FoodGroup()
        {
            Name = "";
            Description = "";
            ImageFileName = "";
        }

        public FoodGroup(string theName, string theDescription, string theImageFileName)
        {
            Name = theName;
            Description = theDescription;
            ImageFileName = theImageFileName;
        }        

        public override string ToString()
        {
            return Name;
        }

        public void Add(FoodSource item)
        {
            list.Add(item);
        }

    } // End of class FoodGroup.
} // End of namespace FoodGroupClass.
