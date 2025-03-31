using System.ComponentModel.DataAnnotations;

namespace Application.Dtos;

public class VerifyRequestDto
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string Token{ get; set; }
}