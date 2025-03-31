using Application.Exceptions;
using Application.Interfaces.Repository;

namespace Application.Services;

public class VerificationCodeService
{
    private readonly IVerificationCodeRepository _verificationCodeRepository;

    public VerificationCodeService(IVerificationCodeRepository verificationCodeRepository)
    {
        _verificationCodeRepository = verificationCodeRepository;
    }
    
    public VerificationCode GetVerificationCode(Guid id)
    {
        var verificationCode = GetByIdOrThrow(id);
        return verificationCode;
    }

    public List<VerificationCode> GetVerificationCodes()
    {
        return _verificationCodeRepository.GetAll();
    }

    public VerificationCode CreateVerificationCode(VerificationCode verificationCode)
    {
        _verificationCodeRepository.Create(verificationCode);
        return verificationCode;
    }

    public VerificationCode UpdateVerificationCode(VerificationCode verificationCode)
    {
        _verificationCodeRepository.Update(verificationCode);
        return verificationCode;
    }

    private VerificationCode GetByIdOrThrow(Guid id)
    {
        var verificationCode = _verificationCodeRepository.GetById(id);
        if (verificationCode == null)
        {
            throw new EntityNotFoundException<VerificationCode>(nameof(VerificationCode.Id), id.ToString());
        }
        return verificationCode;
    }
}