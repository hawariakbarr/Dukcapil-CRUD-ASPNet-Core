using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace ASPNet_Dukcapil_CRUD.Models
{
    public class Dukcapil
    {
        [Key]
        public int DukcapilID {get; set;}

        [Required(ErrorMessage = "Please enter NIK it is required")]
        [MaxLength(16)]
        [MinLength(16)]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number.")]
        public string NIK { get; set; }

        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        string _name;
        [Required(ErrorMessage = "Please enter name it is required")]
        public string Name
        {
            get { return _name; }
            set { _name = textInfo.ToTitleCase(value); } // Check for null ?
        }

        string _maidenName;
        [Required(ErrorMessage = "Please enter maiden name it is required")]
        [DisplayName("Maiden Name")]
        public string MaidenName
        {
            get { return _maidenName; }
            set { _maidenName = textInfo.ToTitleCase(value); } // Check for null ?
        }

        [Required(ErrorMessage = "Please enter birth date it is required")]
        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BrithDate { get; set; }

        [Required(ErrorMessage = "Please enter gender it is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter religion it is required")]
        [DisplayName("Religion")]
        public int ReligionID { get; set; }

        [Required(ErrorMessage = "Please enter marital status it is required")]
        [DisplayName("Marital Status")]
        public int MaritalID { get; set; }

        public Religion Religion { get; set; }
        public Marital Marital { get; set; }

    }
}
