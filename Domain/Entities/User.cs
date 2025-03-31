using Domain.Validations.Validators;
using Microsoft.Extensions.Options;

namespace Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = "Студент";
    public string Email { get; set; }
    public Group Group  { get; set; }
    public Guid GroupId { get; set; }
    public bool IsVerified { get; set; } = false;

    public ICollection<VerificationCode> VerificationCodes { get; set; } = new List<VerificationCode>();

    public User() {}
    private void Validate()
    {
        var validate = new UserValidator();
        validate.Validate(this);
    }
    public void Update(User user)
    {
        Name = user.Name;
        Email = user.Email;
        Group = user.Group;
        IsVerified = user.IsVerified;
        GroupId = user.GroupId;
    }
    //post Email -> письмо на емэйл с ссылкой на подтверждение ->update перейдя по ссылке в бд емэйл отмечается как верефицированный? -> с него можно зайти
    public User(string name, string email, Group group, bool isVerified)
    {
        Name = name;
        Email = email;
        Group = group;
        IsVerified = isVerified;
        GroupId = group.Id;
        Validate();
    }
}