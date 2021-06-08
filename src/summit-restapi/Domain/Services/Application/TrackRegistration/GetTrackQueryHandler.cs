using CfjSummit.Domain.Models.DTOs.Tracks;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.TrackRegistration
{
    public class GetTrackQueryHandler : IRequestHandler<GetTrackQuery, TrackDTO>
    {
        public Task<TrackDTO> Handle(GetTrackQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
