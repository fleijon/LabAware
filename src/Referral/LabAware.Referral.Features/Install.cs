using Microsoft.Extensions.DependencyInjection;
using MediatR;
using LabAware.Referral.Store;
using LabAware.Referral.Parse;

namespace LabAware.Referral.Features;

public static class ReferralInstall
{
    public static IServiceCollection AddReferralFeatures(this IServiceCollection services) =>
        services.AddMediatR(typeof(AddReferral.AddReferral.Handler))
                .AddTransient<IStore, Store.Store>()
                .AddTransient<IReferralParser, ReferralParser>();
}
