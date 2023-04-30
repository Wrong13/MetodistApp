using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("DbAdmins")]
    public class DbAdmin : User
    {
        public string Post { get; set; } 
    }
}
