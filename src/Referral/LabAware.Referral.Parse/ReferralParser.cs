using ErrorOr;

namespace LabAware.Referral.Parse;

public class ReferralParser : IReferralParser
{

    public Task<ErrorOr<Referral>> Parse(Stream content, string format, int version, CancellationToken token) =>
        format.Replace(".", "").ToUpperInvariant() switch
        {
            "JSON" => JsonContent(content),
            _ => throw new InvalidOperationException($"Format '{format}' is not recognized as a valid referral format.")
        };

    private static async Task<ErrorOr<Referral>> JsonContent(Stream content)
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            return Error.Failure(ex.Message);
        }
    }
}
