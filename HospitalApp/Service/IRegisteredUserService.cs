using HospitalApp.Model;
using System;

public interface IRegisteredUserService
{
    RegisteredUser GetRegisteredUser(String username, String password);
}