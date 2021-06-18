﻿namespace CfjSummit.Domain.Models.Entities
{
    public class ProgramUserProfile : Entity
    {
        protected ProgramUserProfile()
        {

        }

        public ProgramUserProfile(int programRole, long programId, long userProfileId)
        {
            ProgramRole = programRole;
            ProgramId = programId;
            UserProfileId = userProfileId;
        }
        public Program Program { private set; get; }
        public long ProgramId { private set; get; }
        public UserProfile UserProfile { private set; get; }
        public long UserProfileId { private set; get; }
        //1:Owner,2:Member
        public int ProgramRole { private set; get; }
    }
}
