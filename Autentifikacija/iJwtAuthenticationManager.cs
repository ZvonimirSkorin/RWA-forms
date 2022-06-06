using System;

namespace Autentifikacija
{
    public interface iJwtAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
}


