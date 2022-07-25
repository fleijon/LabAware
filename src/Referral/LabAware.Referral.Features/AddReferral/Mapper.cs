namespace LabAware.Referral.Features.AddReferral;

internal static class Mapper
{
    public static ReferralViewModel Map<T>(this ParseReferralFile.Referral target) where T: ReferralViewModel =>
        new()
        {
            Id = target.Id,
            Study = target.Study,
            PatientInfo = target.PatientInfo.Map<PatientInfoViewModel>(),
            Samples = target.Samples.Select(s => s.Map<SampleViewModel>()).ToList()
        };
    public static PatientInfoViewModel Map<T>(this ParseReferralFile.PatientInfo target) where T: PatientInfoViewModel =>
        new()
        {
            Id = target.Id,
            Name = target.Name,
            BirthDate = target.BirthDate
        };
    public static SampleViewModel Map<T>(this ParseReferralFile.Sample target) where T: SampleViewModel =>
        new()
        {
            Id = target.Id,
            SampleType = target.SampleType
        };

}
