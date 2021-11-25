using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNet_Dukcapil_CRUD.Models
{
    public class MaritalStatus
    {
        [Key]
        public int MaritalID { get; set; }
        public string MaritalDesc { get; set; }
    }
}
