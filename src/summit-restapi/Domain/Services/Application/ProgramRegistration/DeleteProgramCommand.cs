using MediatR;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class DeleteProgramCommand : IRequest<int>
    {
        public string ProgramId { set; get; }

        public DeleteProgramCommand(string programId)
        {
            ProgramId = programId;
        }
    }
}
