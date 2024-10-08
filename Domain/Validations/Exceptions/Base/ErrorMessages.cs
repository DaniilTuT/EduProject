namespace Domain.Validations;

/// <summary>
/// Класс сообщений об ошибках
/// </summary>
public abstract class ErrorMessages
{
    /// <summary>
    /// Сообщение об исключении null
    /// </summary>
    public const string NullError = "{0} является null.";

    /// <summary>
    /// Сообщение об исключении empty
    /// </summary>
    public const string EmptyError = "{0} пусто.";
    
    /// <summary>
    /// Сообщение об ошибке не найденной сущности
    /// </summary>
    public const string NotFoundError = "Сущность {0} с свойством {1} = {2} не была найдена.";
}