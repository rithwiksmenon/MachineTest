using SalesManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.Repository
{
    public class LoginRepository : ILoginRepository
    {
        //database/json
        SalesDBContext db;

        //Constructor dependency injection
        public LoginRepository(SalesDBContext _db)
        {
            db = _db;
        }

        //login
        public Tbluser validateUser(string username, string password)
        {
            if (db != null)
            {
                Tbluser dbuser = db.Tbluser.FirstOrDefault(em => em.UserName == username && em.UserPassword == password);
                if (dbuser != null)
                {
                    return dbuser;
                }
            }
            return null;
        }
    }
}
