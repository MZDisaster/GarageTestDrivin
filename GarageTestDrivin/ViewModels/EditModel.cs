using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageTestDrivin.ViewModels
{
    public class EditModel
    {
        [Required]
        public string RegNr { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int TypeId { get; set; }
        [Required]
        public int OwnerId { get; set; }
    }
}