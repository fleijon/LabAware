using System.Net.Sockets;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using ErrorOr;
using FluentAssertions;
using LabAware.Referral.Store;
using Moq;
using Xunit;

namespace LabAware.Referral.Features.AddReferral.Tests.Unit;

public class AddReferral_Tests
{
    [Theory]
    [AutoData]
    public async Task Should_Add_Referral_To_Store(AddReferral.Referral referral)
    {
        // arrange
        var storeMock = new Mock<IStore>();
        storeMock.Setup(s => s.AddReferral(It.Is<Store.Referral>(r => r.Id == referral.Id)))
                 .ReturnsAsync(Result.Created);

        var request = new AddReferral.Request(referral);
        var handler = new AddReferral.Handler(storeMock.Object);

        // act
        var response = await handler.Handle(request, new System.Threading.CancellationToken());

        // assert
        response.IsError.Should().BeFalse();
        storeMock.Verify(s => s.AddReferral(It.Is<Store.Referral>(r => r.Id == referral.Id)), Times.Once);
    }

}
