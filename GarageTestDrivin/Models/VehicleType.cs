using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageTestDrivin.Models
{
    public class VehicleType
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Type")]
        public string Name { get; set; }

        public virtual List<Vehicle> Vehicles { get; set; }
    }
}