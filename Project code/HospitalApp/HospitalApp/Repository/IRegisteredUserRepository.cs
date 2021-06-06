using HospitalApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IRegisteredUserRepository
{
    RegisteredUser GetRegisteredUser(String username, String password);
}
