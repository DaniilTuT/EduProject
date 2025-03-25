using Domain.Entities;

public class VerificationCode
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }                 // Связь с пользователем
    public string Code { get; set; }                 // Код подтверждения
    public DateTime ExpirationTime { get; set; }     // Срок действия кода

    // Навигационное свойство для связи с пользователем
    public User User { get; set; }
}