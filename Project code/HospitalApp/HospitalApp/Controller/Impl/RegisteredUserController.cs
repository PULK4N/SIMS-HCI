using HospitalApp.Model;
using System;

public class RegisteredUserController
{
    private IRegisteredUserService _registeredUserService;

    public RegisteredUserController(IRegisteredUserService registeredUserService)
    {
        this._registeredUserService = registeredUserService;
    }

    public RegisteredUser GetRegisteredUser(String username, String password)
    {
        return _registeredUserService.GetRegisteredUser(username, password);
    }
}