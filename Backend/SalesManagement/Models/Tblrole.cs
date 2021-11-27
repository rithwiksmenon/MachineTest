using System;
using System.Collections.Generic;

namespace SalesManagement.Models
{
    public partial class Tblrole
    {
        public Tblrole()
        {
            Tbluser = new HashSet<Tbluser>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Tbluser> Tbluser { get; set; }
    }
}
