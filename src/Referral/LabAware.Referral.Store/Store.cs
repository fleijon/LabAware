using ErrorOr;

namespace LabAware.Referral.Store;

public class Store : IStore
{
    public Task<ErrorOr<Created>> AddReferral(Referral referral) => throw new NotImplementedException();
    public Task<ErrorOr<Referral>> GetReferral(string referralId) => throw new NotImplementedException();
}
