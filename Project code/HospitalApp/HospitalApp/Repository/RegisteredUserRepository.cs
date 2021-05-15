using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;


public class RegisteredUserRepository : IRegisteredUserRepository
{
    public RegisteredUser GetRegisteredUser(string username, string password)
    {
        return (from u in HospitalDB.Instance.RegisteredUsers where u.Username == username && u.Password == password select u).FirstOrDefault();
    }
}

