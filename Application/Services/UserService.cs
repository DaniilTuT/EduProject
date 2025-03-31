using Application.Exceptions;
using Application.Interfaces.Repository;
using Domain.Entities;

namespace Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public ICollection<VerificationCode> GetVerificationToken(Guid userId)
    {
        var user = GetByIdOrThrow(userId);
        return user.VerificationCodes;
    }

    public User SetUserVerified(Guid userId)
    {
        var user = GetByIdOrThrow(userId);
        user.IsVerified = true;
        return user;
    }


    public User GetUserById(Guid userId)
    {
        var user = GetByIdOrThrow(userId);
        return user;
    }

    public List<User> GetAllUsers()
    {
        var users = _userRepository.GetAll();
        return users;
    }

    public User CreateUser(User user)
    {
        _userRepository.Create(user);
        return user;
    }
    
    
    public User UpdateUser(User user)
    {
        var less = GetByIdOrThrow(user.Id);
        less.Update(user);
        _userRepository.Update(less);
        return user;
    }
    
    
    public void Delete(Guid id)
    {
        var shedule = GetByIdOrThrow(id);
        _userRepository.Delete(shedule);
    }

    
    
    private User GetByIdOrThrow(Guid id)
    {
        var user = _userRepository.GetById(id);
        if (user == null)
        {
            throw new EntityNotFoundException<User>(nameof(User.Id), id.ToString());
        }

        return user;
    }
}