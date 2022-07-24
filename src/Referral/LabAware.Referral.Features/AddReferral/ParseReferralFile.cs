using ErrorOr;
using LabAware.Referral.Parse;
using MediatR;

namespace LabAware.Referral.Features.AddReferral;

public static class ParseReferralFile
{
    public record Request(Stream Content, string Format, int Version) : IRequest<ErrorOr<Referral>>;
    public record Referral(string Id, PatientInfo PatientInfo, string Study, IReadOnlyCollection<Sample> Samples);
    public record PatientInfo(string Id, string Name, DateTime BirthDate);
    public record Sample(string Id, string SampleType);

    public class Handler : IRequestHandler<Request, ErrorOr<Referral>>
    {
        private readonly IReferralParser _parser;

        public Handler(IReferralParser parser) => _parser = parser;

        public async Task<ErrorOr<Referral>> Handle(Request request, CancellationToken cancellationToken)
        {
            var parseResult = await _parser.Parse(request.Content, request.Format, request.Version, cancellationToken);

            return parseResult.Match<ErrorOr<Referral>>(
                (parsedContent) => parsedContent.Map<Referral>(),
                (errors) => errors
            );
        }
    }

    public static Referral Map<T>(this Parse.Referral target) where T: Referral =>
        new(target.Id,
            target.PatientInfo.Map<PatientInfo>(),
            target.Study.Name,
            target.Samples.Select(s => s.Map<Sample>()).ToList());
    public static PatientInfo Map<T>(this Parse.PatientInfo target) where T: PatientInfo =>
        new(target.Id, target.Name, target.BirthDate);
    public static Sample Map<T>(this Parse.Sample target) where T: Sample =>
        new(target.Id, target.SampleType);
}
