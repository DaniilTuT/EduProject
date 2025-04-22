using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.GroupDtos;

public class GroupUpdateDto
{
    [Required]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Имя должно содержать от 3 до 20 символов.")]
    public string GroupName { get; set; }
    [Required]
    public Guid Id { get; set; }
}