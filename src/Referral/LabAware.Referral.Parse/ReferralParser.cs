using ErrorOr;

namespace LabAware.Referral.Parse;

public class ReferralParser : IReferralParser
{

    public Task<ErrorOr<Referral>> Parse(Stream content, string format, int version, CancellationToken token) =>
        format.Replace(".", "").ToUpperInvariant() switch
        {
            "JSON" => JsonContent(content),
            _ => Sample(content)
            //_ => throw new InvalidOperationException($"Format '{format}' is not recognized as a valid referral format.")
        };

    private static async Task<ErrorOr<Referral>> JsonContent(Stream content)
    {
        try
        {
            return new Referral(
                Guid.NewGuid().ToString(),
                new PatientInfo(Guid.NewGuid().ToString(), "Abc Def", DateTime.Now.AddYears(-60)),
                new Study("Study1"),
                new Sample[] { new Sample(Guid.NewGuid().ToString(), "SampleType1") });
        }
        catch (Exception ex)
        {
            return Error.Failure(ex.Message);
        }
    }

    private static async Task<ErrorOr<Referral>> Sample(Stream content)
    {
        try
        {
            return new Referral(
                Guid.NewGuid().ToString(),
                new PatientInfo(Guid.NewGuid().ToString(), "Abc Def", DateTime.Now.AddYears(-60)),
                new Study("Study1"),
                new Sample[] { new Sample(Guid.NewGuid().ToString(), "SampleType1") });
        }
        catch (Exception ex)
        {
            return Error.Failure(ex.Message);
        }
    }
}
