using Application.Interfaces.Repository;
using Infrastructure.Dal.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories;

public class VerificationCodeRepository : IVerificationCodeRepository
{
    private readonly ProjectDbContext _projectDbContext;

    public VerificationCodeRepository(ProjectDbContext projectDbContext)
    {
        _projectDbContext = projectDbContext;
    }

    public VerificationCode? GetById(Guid id)
    {
        var verificationCode = _projectDbContext.VerificationCodes.FirstOrDefault(v => v.Id == id);
        return verificationCode;
    }

    public List<VerificationCode> GetAll()
    {
        var verificationCodes = _projectDbContext.VerificationCodes.ToList();
        return verificationCodes;
    }

    public void Create(VerificationCode entity)
    {
        _projectDbContext.VerificationCodes.AddAsync(entity);
        _projectDbContext.SaveChangesAsync();
    }

    public bool Update(VerificationCode entity)
    {
        _projectDbContext.VerificationCodes.Entry(entity).State = EntityState.Modified;
        _projectDbContext.SaveChangesAsync();
        return true;
    }

    public void Delete(VerificationCode entity)
    {
        var entitys = _projectDbContext.VerificationCodes.Find(entity.Id);
        _projectDbContext.VerificationCodes.Remove(entitys);
        _projectDbContext.SaveChangesAsync();
    }
}