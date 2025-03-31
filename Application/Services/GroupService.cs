using Application.Exceptions;
using Application.Interfaces.Repository;
using Domain.Entities;

namespace Application.Services;

public class GroupService
{
    private readonly IGroupRepository _groupRepository;

    public GroupService(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public Group GetGroupById(Guid id)
    {
        var group = GetByIdOrThrow(id);
        return group;
    }

    public List<Group> GetAllGroups()
    {
        var groups = _groupRepository.GetAll();
        return groups;
    }

    public Group CreateGroup(Group group)
    {
        _groupRepository.Create(group);
        return group;
    }

    public Group UpdateGroup(Group group)
    {
        _groupRepository.Update(group);
        return group;
    }
    private Group GetByIdOrThrow(Guid id)
    {
        var group = _groupRepository.GetById(id);
        if (group == null)
        {
            throw new EntityNotFoundException<Group>(nameof(Group.Id), id.ToString());
        }
        
        return group;
    }
}