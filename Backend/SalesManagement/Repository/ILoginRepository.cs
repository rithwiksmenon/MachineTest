using SalesManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.Repository
{
    public interface ILoginRepository
    {
        //login
        public Tbluser validateUser(string username, string password);
    }
}
