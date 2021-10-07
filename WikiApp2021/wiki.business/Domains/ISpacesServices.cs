using System.Collections.Generic;

namespace wiki.business.Domains
{
    public interface ISpacesServices
    {
        public List<View_Models.SpaceModel> GetSpaces(string userId);
        public View_Models.SpaceModel GetSpaceById(int id);
        public View_Models.SpaceModel CreateSpace(View_Models.SpaceModel spaceModel);
        public data.Enums.HttpCode DeleteSpace(int spaceId, string userId);
        public View_Models.SpaceModel EditSpace(View_Models.SpaceModel spaceModel);
        public List<View_Models.SpaceModel> GetSpacesByUserId(string uid);
    }
}
