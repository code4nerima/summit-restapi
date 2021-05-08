using CfjSummit.Domain.Models.Entities;
using System.Text.Json.Serialization;

namespace CfjSummit.Domain.Models.DTOs.Tracks
{
    public class TrackDTO : TrackKeyDataDTO
    {
        [JsonPropertyName("name")]
        public MultilingualValue Name { set; get; }

        public TrackDTO(Track track)
        {
            TrackGuid = track.TrackGuid;
            Name = new MultilingualValue()
            {
                Ja = track.Name_Ja,
                En = track.Name_En,
                ZhTw = track.Name_Zh_Tw,
                ZhCn = track.Name_Zh_Cn
            };
        }
    }
}
