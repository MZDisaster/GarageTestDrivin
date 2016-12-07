using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageTestDrivin.Tests.Models
{
    public class CreateModel
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
