using ErrorOr;

namespace LabAware.Referral.Parse;

public interface IReferralParser
{
    Task<ErrorOr<Referral>> Parse(Stream content, string format, int version, CancellationToken token = default);
}

public record Referral(string Id, PatientInfo PatientInfo, Study Study, IReadOnlyCollection<Sample> Samples);
public record PatientInfo(string Id, string Name, DateTime BirthDate);
public record Sample(string Id, string SampleType);
public record struct Study(string Name);
