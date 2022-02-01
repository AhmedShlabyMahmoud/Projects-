using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FristProjectIti.Models
{
    public class Doctor
    {

        public int ID { get; set; }
        [Required(ErrorMessage ="You have to enter valid Name")]
        [MinLength(3,ErrorMessage =("name mustn't be less than 3 character"))]
        [MaxLength(25, ErrorMessage = ("name mustn't be more than 25 character"))]
        public string FullName { get; set; }
        public string Description { get; set; }
        public ICollection<Patient> patients { get; set; }
    }
}
