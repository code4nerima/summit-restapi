using CfjSummit.Domain.Models.DTOs.Programs;
using CfjSummit.Domain.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace CfjSummit.Domain.Models.Entities
{
    public class Program : Entity
    {
        private Program()
        {

        }
        public Program(ProgramTitleDTO title, ProgramCategory category)
        {
            ProgramId = Guid.NewGuid().ToString();
            Title_Ja = title.Ja;
            Title_En = title.En;
            Title_Zh_Tw = title.ZhTw;
            Title_Zh_Cn = title.ZhCn;
            ProgramCategory = (int)category;
        }
        public string ProgramId { get; init; }
        public string Title_Ja { private set; get; }
        public string Title_En { private set; get; }
        public string Title_Zh_Tw { private set; get; }
        public string Title_Zh_Cn { private set; get; }
        [Required]
        public int ProgramCategory { private set; get; }
        public string Description_Ja { private set; get; }
        public string Description_En { private set; get; }
        public string Description_Zh_Tw { private set; get; }
        public string Description_Zh_Cn { private set; get; }

        public void Update(ProgramTitleDTO title, ProgramCategory category, ProgramDescriptionDTO description)
        {
            Title_Ja = title.Ja ?? Title_Ja;
            Title_En = title.En ?? Title_En;
            Title_Zh_Tw = title.ZhTw ?? Title_Zh_Tw;
            Title_Zh_Cn = title.ZhCn ?? Title_Zh_Cn;

            ProgramCategory = (int)category;

            Description_Ja = description.Ja ?? Description_Ja;
            Description_En = description.En ?? Description_En;
            Description_Zh_Tw = description.ZhTw ?? Description_Zh_Tw;
            Description_Zh_Cn = description.ZhCn ?? Description_Zh_Cn;
        }
    }
}
