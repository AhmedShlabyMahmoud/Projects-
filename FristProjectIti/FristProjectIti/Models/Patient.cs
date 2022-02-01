using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FristProjectIti.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You have to provide a Valid Full Name  ")]
        [DisplayName("FullName")]
        [MinLength(11,ErrorMessage ="Full name must be more than 10 charachter")]
        [MaxLength(50, ErrorMessage = "Full name must be less than 50 charachter")]
        public string  Fullname { get; set; }



        [DisplayName("Age")]
        [Required]
        [Range(0, 150, ErrorMessage = "Age must be in Range 0:150")]
        public int Age { get; set; }
        [DisplayName("Diagnesis")]
        [Required]
        public string Diagnesis { get; set; }
        public string Treatment { get; set; }
        public string Notes { get; set; }
    }
}
