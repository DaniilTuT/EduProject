using Domain.Entities;

public class VerificationCode : BaseEntity
{
    public VerificationCode(){}

    public VerificationCode(Guid userId, string token, DateTime expirationTime, User user)
    {
        UserId = userId;
        Token = token;
        ExpirationTime = expirationTime;
        User = user;
        UserId = user.Id;
    }

    public Guid Id { get; set; }
    public Guid UserId { get; set; }                 // Связь с пользователем
    public string Token { get; set; }                 // Код подтверждения
    public DateTime ExpirationTime { get; set; }     // Срок действия кода

    // Навигационное свойство для связи с пользователем
    public User User { get; set; }
}