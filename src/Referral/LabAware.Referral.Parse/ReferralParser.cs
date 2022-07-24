namespace LabAware.Referral.Parse;

public class ReferralParser : IReferralParser
{
    public Task<object> Parse(Stream content, string format, int version) =>
        format.Replace(".", "").ToUpperInvariant() switch
        {
            "JSON" => JsonContent(content),
            _ => throw new InvalidOperationException($"Format '{format}' is not recognized as a valid referral format.")
        };

    private static Task<object> JsonContent(Stream content)
    {
        throw new NotImplementedException();
    }
}
