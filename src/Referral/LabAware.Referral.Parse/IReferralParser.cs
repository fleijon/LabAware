namespace LabAware.Referral.Parse;

public interface IReferralParser
{
    Task<object> Parse(Stream content, string format, int version);
}
