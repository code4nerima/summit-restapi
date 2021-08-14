using CfjSummit.Domain.Models.DTOs;
using CfjSummit.Domain.Models.DTOs.Tracks;
using CfjSummit.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.TrackRegistration
{
    public class ListTrackQueryHandler : IRequestHandler<ListTrackQuery, ListTrackResponseDTO>
    {
        private readonly ITrackRepository _repository;

        public ListTrackQueryHandler(ITrackRepository repository)
        {
            _repository = repository;
        }

        public async Task<ListTrackResponseDTO> Handle(ListTrackQuery request, CancellationToken cancellationToken)
        {
            var takeCount = request.ListTrackRequestDTO.Limit;
            if (takeCount <= 0) { takeCount = int.MaxValue; }

            var query = await _repository.GetAll()
                                        .OrderBy(x => x.Name_Ja)
                                        .Skip(request.ListTrackRequestDTO.Start)
                                        .Take(takeCount)
                                        .ToListAsync(cancellationToken: cancellationToken);

            return new ListTrackResponseDTO()
            {
                TotalCount = query.Count,
                Tracks = query.Select(x => new TrackDTO()
                {
                    TrackGuid = x.TrackGuid,
                    Name = new MultilingualValue()
                    {
                        Ja = x.Name_Ja,
                        En = x.Name_En,
                        ZhTw = x.Name_Zh_Tw,
                        ZhCn = x.Name_Zh_Cn
                    },
                    BroadcastingURL = x.BroadcastingURL,
                    MeetingId = x.MeetingId,
                    MeetingPasscode = x.MeetingPasscode,
                    MeetingUrl = x.MeetingUrl,
                    Station = x.Station,
                    StreamKey = x.StreamKey,
                    StreamUrl = x.StreamUrl,
                    UdTalkWebURL = x.UdTalkWebURL,
                    UdTalkAppURL = x.UdTalkAppURL
                }
                ).ToList()
            };
        }
    }
}
