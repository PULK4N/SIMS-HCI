using HospitalApp.Model;
using System;

class LoginService : ILoginService
{
    public RegisteredUser Login(String username, String password)
    {
        return Map.RegisteredUserService.GetRegisteredUser(username, password);
    }

}

