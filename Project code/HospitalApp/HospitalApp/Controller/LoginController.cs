using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
