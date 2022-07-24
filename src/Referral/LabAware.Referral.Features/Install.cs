using Microsoft.Extensions.DependencyInjection;
using MediatR;
using LabAware.Referral.Store;

namespace LabAware.Referral.Features;

public static class ReferralInstall
{
    public static IServiceCollection AddReferralFeatures(this IServiceCollection services) =>
        services.AddMediatR(typeof(AddReferral.AddReferral.Handler))
                .AddTransient<IStore, Store.Store>();

}
