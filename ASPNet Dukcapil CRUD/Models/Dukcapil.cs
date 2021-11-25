using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNet_Dukcapil_CRUD.Models
{
    public class Dukcapil
    {
        [Key]
        public int DukcapilID {get; set;}
        [Required(ErrorMessage = "Please enter NIK it is required")]
        [MaxLength(16), MinLength(16)]
        public int NIK { get; set; }
        [Required(ErrorMessage = "Please enter name it is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter maiden name it is required")]
        public string MaidenName { get; set; }
        [Required(ErrorMessage = "Please enter birth date it is required")]
        [DataType(DataType.Date)]
        public DateTime BrithDate { get; set; }
        [Required(ErrorMessage = "Please enter gender it is required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please enter religion it is required")]
        public int ReligionID { get; set; }
        [Required(ErrorMessage = "Please enter marital status it is required")]
        public string MaritalID { get; set; }
        public Religion Religion { get; set; }
        public MaritalStatus MaritalStatus { get; set; }

    }
}
