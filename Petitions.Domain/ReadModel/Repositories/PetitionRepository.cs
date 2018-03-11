using Petitions.Domain.ReadModel.Repositories.Interfaces;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;

namespace Petitions.Domain.ReadModel.Repositories
{
    public class PetitionRepository : BaseRepository, IPetitionRepository
    {
        public PetitionRepository(IConnectionMultiplexer redisConnection) : base(redisConnection, "petition") { }

        public PetitionRM GetByID(int petitionId)
        {
            return Get<PetitionRM>(petitionId);
        }

        public List<PetitionRM> GetMultiple(List<int> petitionIds)
        {
            return GetMultiple<PetitionRM>(petitionIds);
        }

        public IEnumerable<PetitionRM> GetAll()
        {
            return Get<List<PetitionRM>>("all");
        }

        public void Save(PetitionRM petition)
        {
            Save(petition.PetitionId, petition);
            MergeIntoAllCollection(petition);
        }

        private void MergeIntoAllCollection(PetitionRM petition)
        {
            List<PetitionRM> allPetitions = new List<PetitionRM>();
            if (Exists("all"))
            {
                allPetitions = Get<List<PetitionRM>>("all");
            }

            //If the district already exists in the ALL collection, remove that entry
            if (allPetitions.Any(x => x.PetitionId == petition.PetitionId))
            {
                allPetitions.Remove(allPetitions.First(x => x.PetitionId == petition.PetitionId));
            }

            //Add the modified district to the ALL collection
            allPetitions.Add(petition);

            Save("all", allPetitions);
        }
    }
}
