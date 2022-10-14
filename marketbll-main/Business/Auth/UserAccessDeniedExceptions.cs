using System;

namespace Business.Auth;

public class UserAccessDeniedExceptions : Exception
{
    public UserAccessDeniedExceptions(string name) : base($"User: {name} access denied!") {}
}