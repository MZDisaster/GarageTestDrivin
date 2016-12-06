using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GarageTestDrivin.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Color { get; set; }

        [Required]
        [RegularExpression("^[A-Z]{3}[0-9]{3}$")]
        public string RegNr { get; set; }
        [Required]
        [ForeignKey("Type")]
        public int TypeId { get; set; }
        [Required]
        [ForeignKey("Owner")]
        public int OwnerId { get; set; }

        public virtual Owner Owner { get; set; }

        public virtual VehicleType Type { get; set; }
    }
}