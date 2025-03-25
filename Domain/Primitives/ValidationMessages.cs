namespace Domain.Primitives;
public static class ValidationMessages
{
    public static string NotNull = "{PropertyName} не инициализирована.";
    public static string NotEmpty = "{PropertyName} не заполнен.";
    public static string WrongLength="{PropertyName} должен быть не меньше {MinLength} и не больше {MaxLength}.";
    public static string WrongTime = "{PropertyName} не может быть меньше чем конец.";
    public static string WrongEmail = "{PropertyName} не является E-mail адрессом";
}