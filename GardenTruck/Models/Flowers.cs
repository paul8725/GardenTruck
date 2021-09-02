using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GardenTruck.Models
{
    public class Flowers
    {
        // flower models that will added to the database
        public int Id { get; set; }

        [Display(Name = "Flower")]
        public string Flower { get; set; }

        [Display(Name = "Age")]
        public string Age { get; set; }

        // price coluom
        [Display(Name = "Price ")]
        public string Price { get; set; }


    }
}
