using MediatR;
using NS.Application.Common;

namespace NS.Application.Product.Commands.ChangeAvailability;

public class ChangeProductAvailabilityCommand : IRequest<BaseResponse>
{
    public long Id { get; set; }
    public bool AvailabilityState { get; set; }
}