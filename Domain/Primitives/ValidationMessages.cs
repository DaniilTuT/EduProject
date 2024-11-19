namespace Domain.Primitives;
/// <summary>
/// Сообщения об ошибках при валидации
/// </summary>
public static class ValidationMessages
{
    /// <summary>
    /// Сообщение об исключении null
    /// </summary>
    public static string NotNull = "{PropertyName} не инициализирована.";
    /// <summary>
    /// Сообщение об исключении empty
    /// </summary>
    public static string NotEmpty = "{PropertyName} не заполнен.";
    /// <summary>
    /// Сообщение об исключении длины
    /// </summary>
    public static string WrongLength="{PropertyName} должен быть не меньше {MinLength} и не больше {MaxLength}.";
    /// <summary>
    /// Сообщение об исключении времени
    /// </summary>
    public static string WrongTime = "{PropertyName} не может быть меньше чем конец.";
}