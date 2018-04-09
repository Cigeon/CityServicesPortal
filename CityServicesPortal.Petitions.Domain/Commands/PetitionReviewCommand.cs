using CityServicesPortal.Petitions.Domain.Core.Commands;
using System;

namespace CityServicesPortal.Petitions.Domain.Commands
{
    public class PetitionReviewCommand : Command
    {
        public PetitionReviewCommand(Guid id, Guid userId, DateTime created, string text)
        {
            Id = id;
            UserId = userId;
            Created = created;
            Text = text;
        }

        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public DateTime Created { get; protected set; }
        public string Text { get; protected set; }
    }
}
