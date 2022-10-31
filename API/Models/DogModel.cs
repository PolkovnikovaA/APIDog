using API.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class DogModel
    {
        public DogModel(Dog dog)
        {
            ID = dog.Id;
            Dog1 = dog.Dog1;
            Info = dog.Info;
            Life_expectancy = dog.Life_expectancy;
            Image = dog.Image;
        }
        public int ID { get; set; }
        public string Dog1 { get; set; }
        public string Info { get; set; }
        public int Life_expectancy { get; set; }
        public string Image { get; set; }
    }
}