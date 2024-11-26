namespace Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = "Студент";
    public string Email { get; set; }
    public string Group  { get; set; }
    public bool IsVerified { get; set; }

    public ICollection<VerificationCode> VerificationCodes { get; set; } = new List<VerificationCode>();

    public void Update(User user)
    {
        Name = user.Name;
        Email = user.Email;
        Group = user.Group;
        IsVerified = user.IsVerified;
    }
    //post Email -> письмо на емэйл с ссылкой на подтверждение ->update перейдя по ссылке в бд емэйл отмечается как верефицированный? -> с него можно зайти
    
}