using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multilayer_architecture.Model
{
    public class Department
    {
        [Key]
        public int department_id { get; set; }
        public string department_name { get; set; }
        public short department_staffs { get; set; }
    }
}
