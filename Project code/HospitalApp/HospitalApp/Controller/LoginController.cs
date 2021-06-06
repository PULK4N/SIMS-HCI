using HospitalApp.Model;
using System;


public class LoginController
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    public RegisteredUser Login(String username, String password)
    {
        return _loginService.Login(username, password);
    }
}
