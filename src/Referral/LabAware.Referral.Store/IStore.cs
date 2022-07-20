using ErrorOr;

namespace LabAware.Referral.Store;

public interface IStore
{
    Task<ErrorOr<Created>> AddReferral(Referral referral);
    Task<ErrorOr<Referral>> GetReferral(string referralId);
}

public record Referral(string Id, PatientInfo PatientInfo, Study Study, IReadOnlyCollection<Sample> Samples);
public record PatientInfo(string Id, string Name, DateTime BirthDate);
public record Sample(string Id, string SampleType);
public record struct Study(string Name);
