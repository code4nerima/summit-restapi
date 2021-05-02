using CfjSummit.Domain.Models.DTOs.Programs;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Application.ProgramRegistration
{
    public class ListProgramQueryHandler : IRequestHandler<ListProgramQuery, ListProgramResponseDTO>
    {
        public Task<ListProgramResponseDTO> Handle(ListProgramQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
