using System;
using System.Collections.Generic;
using System.Text;

namespace CityServicesPortal.Petitions.Domain.Models
{
    public enum PetitionStatus
    {
        Verification = 1,
        Voting,
        Consideration,
        Reviewed
    }
}
