using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageTestDrivin.Models
{
    public class Owner
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string PNR { get; set; }

        public virtual List<Vehicle> Vehicles { get; set; }
    }
}