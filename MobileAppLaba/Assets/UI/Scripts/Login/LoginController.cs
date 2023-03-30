using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LoginController
{
    private readonly LoginScreen _loginScreen;


    public LoginController(LoginScreen loginScreen)
    {
        _loginScreen = loginScreen;
    }
}
