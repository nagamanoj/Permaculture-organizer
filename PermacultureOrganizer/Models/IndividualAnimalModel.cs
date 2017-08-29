using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermacultureOrganizer.Models
{
    public class IndividualAnimalModel
    {
        public IndividualAnimalModel()
        {
            IndividualAnimalID = new int();
            Name = string.Empty;
            Gender = string.Empty;
            BreedID = new int();
            BirthDate = new DateTime();
            FatherName = string.Empty;
            FatherID = new int();
            MotherName = string.Empty;
            MotherID = new int();
            BirthPlace = string.Empty;
            DeathDate = new DateTime();
            Description = string.Empty;
            PhotographID = new int();
        }

        public int IndividualAnimalID;
        public string Name;
        public string Gender;
        public int BreedID;
        public DateTime BirthDate;
        public string FatherName;
        public int FatherID;
        public string MotherName;
        public int MotherID;
        public string BirthPlace;
        public DateTime DeathDate;
        public string Description;
        public int PhotographID;
    }
}