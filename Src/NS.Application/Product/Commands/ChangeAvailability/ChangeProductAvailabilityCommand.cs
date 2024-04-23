using MediatR;

namespace NS.Application.Product.Commands.ChangeAvailability;

public class ChangeProductAvailabilityCommand : IRequest
{
    public long Id { get; set; }
    public bool AvailabilityState { get; set; }
}