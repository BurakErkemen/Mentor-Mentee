using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multilayer_architecture.Model
{
    public class Employee
    {
        [Key]
        public int employee_id { get; set; }
        public string employee_name { get; set; }
        public string employee_lastname { get; set; }
        public int employee_identity_card { get; set; }
        public DateTime? employee_entry_date { get; set; }
        public Department department{ get; set; }
    }
}
