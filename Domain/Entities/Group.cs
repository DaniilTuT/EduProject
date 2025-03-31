namespace Domain.Entities;

public class Group : BaseEntity
{
    public Group(string groupName)
    {
        GroupName = groupName;
    }

    public List<Shedule> Shedules { get; set; } = new List<Shedule>();
    
    public List<User> Users { get; set; } = new List<User>();
    public string GroupName { get; set; }
    
    
}