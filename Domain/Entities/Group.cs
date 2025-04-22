using Domain.Validations.Validators;

namespace Domain.Entities;

public class Group : BaseEntity
{
    public Group(string groupName)
    {
        GroupName = groupName;
        Validate();
    }

    private void Validate()
    {
        var validate = new GroupValidator();
        validate.Validate(this);
    }

    public List<Shedule> Shedules { get; set; } = new List<Shedule>();
    public List<User> Users { get; set; } = new List<User>();

    public string GroupName { get; set; }

    public void Update(Group group)
    {
        GroupName = group.GroupName;
        Validate();
    }
    
    
}