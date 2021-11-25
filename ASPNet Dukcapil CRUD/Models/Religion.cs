using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNet_Dukcapil_CRUD.Models
{
    public class Religion
    {
        [Key]
        public int ReligionID { get; set; }
        public string ReligionName { get; set; }
    }
}
