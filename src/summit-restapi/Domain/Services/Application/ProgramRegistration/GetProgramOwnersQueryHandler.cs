using CfjSummit.Domain.Models.DTOs.Programs;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class GetProgramOwnersQueryHandler : IRequestHandler<GetProgramOwnersQuery, GetProgramOwnersResponseDTO>
    {
        public Task<GetProgramOwnersResponseDTO> Handle(GetProgramOwnersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
