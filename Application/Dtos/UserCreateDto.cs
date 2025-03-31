using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Application.Dtos;

public class UserCreateDto
{
    [Required]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Имя должно содержать от 3 до 20 символов.")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    public Group Group  { get; set; }
}