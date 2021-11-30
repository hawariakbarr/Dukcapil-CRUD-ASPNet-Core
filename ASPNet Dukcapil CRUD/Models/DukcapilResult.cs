using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNet_Dukcapil_CRUD.Models
{
    public class DukcapilResult
    {
        [Key]
        public int ResultID { get; set; }
        public string NIK { get; set; }
        public string CheckStatus { get; set; }
    }
}
