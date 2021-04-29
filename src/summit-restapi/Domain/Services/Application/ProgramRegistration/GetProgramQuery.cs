using CfjSummit.Domain.Models.DTOs.Programs;
using MediatR;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class GetProgramQuery : IRequest<ProgramDTO>
    {
        public string ProgramId { set; get; }
        public GetProgramQuery(string programId)
        {
            ProgramId = programId;
        }
    }
}
