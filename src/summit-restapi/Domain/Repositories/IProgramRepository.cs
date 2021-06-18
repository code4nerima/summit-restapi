﻿using CfjSummit.Domain.Models.Entities;
using System.Threading.Tasks;

namespace CfjSummit.Domain.Repositories
{
    public interface IProgramRepository : IRepository<Program>
    {
        public ValueTask<Program> GetProgramWithUserProfilesAsync(string programId);
    }
}
