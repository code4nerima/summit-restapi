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
    public class GetTrackQueryHandler : IRequestHandler<GetTrackQuery, TrackDTO>
    {
        private readonly ITrackRepository _repository;

        public GetTrackQueryHandler(ITrackRepository repository)
        {
            _repository = repository;
        }

        public async Task<TrackDTO> Handle(GetTrackQuery request, CancellationToken cancellationToken)
        {
            var trackDto = await _repository
                .GetAll()
                .Select(x => new TrackDTO()
                {
                    TrackGuid = x.TrackGuid,
                    Name = new MultilingualValue()
                    {
                        Ja = x.Name_Ja,
                        En = x.Name_En,
                        ZhTw = x.Name_Zh_Tw,
                        ZhCn = x.Name_Zh_Cn
                    },
                    BroadcastingURL_1stDay = x.BroadcastingURL_1stDay,
                    BroadcastingURL_2ndDay = x.BroadcastingURL_2ndDay,
                    MeetingId = x.MeetingId,
                    MeetingPasscode = x.MeetingPasscode,
                    MeetingUrl = x.MeetingUrl,
                    Station = x.Station,
                    StreamKey = x.StreamKey,
                    StreamUrl = x.StreamUrl,
                    UdTalkWebURL = x.UdTalkWebURL,
                    UdTalkAppURL = x.UdTalkAppURL
                })
                .SingleOrDefaultAsync(x => x.TrackGuid == request.TrackGuid, cancellationToken: cancellationToken);
            return trackDto;
        }
    }
}
