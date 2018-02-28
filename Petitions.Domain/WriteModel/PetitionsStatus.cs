using System;
using System.Collections.Generic;
using System.Text;

namespace Petitions.Domain.WriteModel
{
    public enum PetitionsStatus
    {
        Verification = 1,
        Voting,
        Consideration,
        Reviewed
    }
}
