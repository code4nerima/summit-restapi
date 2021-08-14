using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Tracks
{
    public class TrackDTO : TrackKeyDataDTO
    {
        [JsonPropertyName("name")]
        public MultilingualValue Name { set; get; }

        [JsonPropertyName("broadcastingURL")]
        public virtual string BroadcastingURL { get; set; }
        [JsonPropertyName("meetingId")]
        public virtual string MeetingId { get; set; }
        [JsonPropertyName("meetingPasscode")]
        public virtual string MeetingPasscode { get; set; }
        [JsonPropertyName("meetingURL")]
        public virtual string MeetingUrl { get; set; }
        [JsonPropertyName("station")]
        public virtual string Station { get; set; }
        [JsonPropertyName("streamKey")]
        public virtual string StreamKey { get; set; }
        [JsonPropertyName("streamURL")]
        public virtual string StreamUrl { get; set; }
        [JsonPropertyName("udtalkWebURL")]
        public virtual string UdTalkWebURL { get; set; }
        [JsonPropertyName("udtalkAppURL")]
        public virtual string UdTalkAppURL { get; set; }

    }
}
