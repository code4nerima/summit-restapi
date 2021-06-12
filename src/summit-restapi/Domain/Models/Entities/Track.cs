using CfjSummit.Domain.Models.DTOs.Tracks;
using System.Collections.Generic;

namespace CfjSummit.Domain.Models.Entities
{
    public class Track : Entity
    {
        private Track()
        {

        }

        public Track(TrackDTO dto)
        {
            TrackGuid = NewGuid;
            Edit(dto);
        }
        public virtual string TrackGuid { set; get; }
        public virtual string Name_Ja { get; private set; }
        public virtual string Name_En { get; private set; }
        public virtual string Name_Zh_Tw { get; private set; }
        public virtual string Name_Zh_Cn { get; private set; }
        public virtual string BroadcastingURL { get; private set; }
        public virtual string MeetingId { get; private set; }
        public virtual string MeetingPasscode { get; private set; }
        public virtual string MeetingUrl { get; private set; }
        public virtual string Station { get; private set; }
        public virtual string StreamKey { get; private set; }
        public virtual string StreamUrl { get; private set; }

        private readonly List<Program> _programs = new();
        public IReadOnlyCollection<Program> Programs => _programs;

        public void Update(TrackDTO dto)
        {
            Edit(dto);
        }


        private void Edit(TrackDTO dto)
        {
            Name_Ja = dto.Name.Ja;
            Name_En = dto.Name.En;
            Name_Zh_Tw = dto.Name.ZhTw;
            Name_Zh_Cn = dto.Name.ZhCn;
            BroadcastingURL = dto.BroadcastingURL;
            MeetingId = dto.MeetingId;
            MeetingPasscode = dto.MeetingPasscode;
            MeetingUrl = dto.MeetingUrl;
            Station = dto.Station;
            StreamKey = dto.StreamKey;
            StreamUrl = dto.StreamUrl;
        }
    }
}
