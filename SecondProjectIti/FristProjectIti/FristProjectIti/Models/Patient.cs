using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

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
        [DisplayName("Doctor")]
        [Range(1 , int.MaxValue , ErrorMessage = "Choose a valid Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctors { get; set; }
        [DisplayName("Date of birth")]
        public DateTime BirthDay  { get; set; }

        [DataType(DataType.Date)]
        public DateTime injuryTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime StartHiringtime { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        [DisplayName("Personal Image")]
        public string PersonalImageName { get; set; }        
        [NotMapped]
        public IFormFile PersonalImageFile { get; set; }

        public String ahmed { get; set; }

        [DisplayName("National Number")]
        public string NationalNumberCard { get; set; }
        [NotMapped]
        public IFormFile NationalNumberCardFile { get; set; }
    }
}
