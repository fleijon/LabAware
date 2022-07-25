namespace LabAware.Referral.Features.AddReferral;

public class ReferralViewModel
{
    public string? Id { get; set; }
    public string? Study { get; set; }
    public PatientInfoViewModel? PatientInfo { get; set; }
    public List<SampleViewModel> Samples { get; set; } = new();
}

public class PatientInfoViewModel
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public DateTime BirthDate { get; set; }
}

public class SampleViewModel
{
    public string? Id { get; set; }
    public string? SampleType { get; set; }
}
