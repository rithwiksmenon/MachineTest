using System;
using System.Collections.Generic;

namespace SalesManagement.Models
{
    public partial class Tbluser
    {
        public Tbluser()
        {
            EmployeeRegistration = new HashSet<EmployeeRegistration>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int? RoleId { get; set; }

        public virtual Tblrole Role { get; set; }
        public virtual ICollection<EmployeeRegistration> EmployeeRegistration { get; set; }
    }
}
