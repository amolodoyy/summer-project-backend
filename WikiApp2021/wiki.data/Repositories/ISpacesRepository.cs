using System.Collections.Generic;
using wiki.data.Entities;
using wiki.data.Enums;

namespace wiki.data.Repositories
{
    public interface ISpacesRepository
    {
        public List<Space> GetSpaces(string userId); 
        Space GetSpaceById(int id);
        Space CreateSpace(Space s);
        HttpCode DeleteSpace(int spaceId, string userId);
        List<Space> GetSpacesByUserId(string uid);
        Space EditSpace(Space s);

    }
}
