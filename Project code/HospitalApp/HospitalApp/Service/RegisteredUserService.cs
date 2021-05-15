using System;

public class RegisteredUserService : IRegisteredUserService
{
    public readonly IRegisteredUserRepository _registeredUserRepository;

    public RegisteredUserService(IRegisteredUserRepository registeredUserRepository)
    {
        _registeredUserRepository = registeredUserRepository;
    }

    public RegisteredUser GetRegisteredUser(String username, String password)
    {
        return _registeredUserRepository.GetRegisteredUser(username, password);
    }
}