using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GardenTruck.Models
{
    public class Seeds
    {
        public int Id { get; set; }
        // seeds table 
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Contact ")]
        public string Contact { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "NumberOfPacket")]
        public string NumberOfPacket { get; set; }
        // foreign key concept 
        // following flower id will be fetched from flower table
        [Display(Name = "FlowerId")]
        public int FlowerId { get; set; }
    }
}
