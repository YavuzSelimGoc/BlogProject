using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.DataAccessLayer
{
    public class Employer
    {
        [Key]
        public int EmployerID { get; set; }
        public string EmployerName { get; set; }
    }
}
