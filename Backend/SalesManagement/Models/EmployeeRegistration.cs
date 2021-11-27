using System;
using System.Collections.Generic;

namespace SalesManagement.Models
{
    public partial class EmployeeRegistration
    {
        public EmployeeRegistration()
        {
            VisitTbale = new HashSet<VisitTbale>();
        }

        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public decimal? PhoneNumber { get; set; }
        public int? UserId { get; set; }

        public virtual Tbluser User { get; set; }
        public virtual ICollection<VisitTbale> VisitTbale { get; set; }
    }
}
