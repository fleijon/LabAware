using MediatR;
using ErrorOr;
using LabAware.Referral.Store;

namespace LabAware.Referral.Features.AddReferral;

public static class AddReferral
{
    public record Request(Referral Referral) : IRequest<ErrorOr<Created>>;

    public record Referral(string Id, PatientInfo PatientInfo, string Study, IReadOnlyCollection<Sample> Samples);
    public record PatientInfo(string Id, string Name, DateTime BirthDate);
    public record Sample(string Id, string SampleType);

    public class Handler : IRequestHandler<Request, ErrorOr<Created>>
    {
        private readonly IStore _store;

        public Handler(IStore store)
        {
            _store = store;
        }

        public Task<ErrorOr<Created>> Handle(Request request, CancellationToken cancellationToken) =>
            _store.AddReferral(request.Referral.Map<Store.Referral>());
    }
}

public static class Mapper
{
    public static Store.Referral Map<T>(this AddReferral.Referral referral) where T : Store.Referral =>
        new(referral.Id,
            referral.PatientInfo.Map<Store.PatientInfo>(),
            new Study(referral.Study),
            referral.Samples.Select(s => s.Map<Store.Sample>()).ToList());

    public static Store.PatientInfo Map<T>(this AddReferral.PatientInfo patientInfo) where T : Store.PatientInfo =>
        new(patientInfo.Id, patientInfo.Name, patientInfo.BirthDate);

    public static Store.Sample Map<T>(this AddReferral.Sample sample) where T : Store.Sample =>
        new(sample.Id, sample.SampleType);

}
