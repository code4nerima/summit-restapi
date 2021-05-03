using CfjSummit.Domain.Models.Entities;
using CfjSummit.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Services.Domain
{
    public class CreateRequestLogCommandHandler : IRequestHandler<CreateRequestLogCommand, int>
    {
        private readonly IRequestLogRepository _repository;

        public CreateRequestLogCommandHandler(IRequestLogRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(CreateRequestLogCommand request, CancellationToken cancellationToken)
        {
            var log = new RequestLog(request.Uid, request.Method, request.Controller,
                request.ContentType, request.RequestBody, request.LocalIpAddress, request.RemoteIpAddress);
            _repository.Add(log);
            return await _repository.SaveChangesAsync();
        }
    }
}
