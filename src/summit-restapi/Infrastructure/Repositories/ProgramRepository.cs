﻿using CfjSummit.Domain.Models.Entities;
using CfjSummit.Domain.Repositories;
using CfjSummit.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CfjSummit.Infrastructure.Repositories
{
    public class ProgramRepository : Repository<Program>, IProgramRepository
    {
        public ProgramRepository(CfjContext context) : base(context)
        {

        }

        public async ValueTask<Program> GetProgramWithUserProfilesAsync(string programId)
        {
            return await _table
                .Include(x => x.ProgramUserProfiles)
                .ThenInclude(x => x.UserProfile)
                .SingleOrDefaultAsync(x => x.ProgramGuid == programId);
        }

    }
}
