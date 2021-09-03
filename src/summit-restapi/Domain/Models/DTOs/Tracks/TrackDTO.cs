using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Tracks
{
    public class TrackDTO : TrackKeyDataDTO
    {
        [JsonPropertyName("name")]
        public MultilingualValue Name { set; get; }
        [JsonPropertyName("broadcastingURL01")]
        public virtual string BroadcastingURL_1stDay { get; set; }
        [JsonPropertyName("broadcastingURL02")]
        public virtual string BroadcastingURL_2ndDay { get; set; }
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
        [JsonPropertyName("udtalkSrURL")]
        public virtual string UdtalkSrURL { get; set; }
        [JsonPropertyName("memo")]
        public virtual string Memo { get; set; }

    }
}
