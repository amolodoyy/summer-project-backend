using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using wiki.business.View_Models;
using wiki.data.Enums;

namespace wiki.business.Domains
{
    public class SpacesServices : ISpacesServices
    {
        private readonly data.Repositories.SpacesRepository repository;
        private readonly IMapper mapper;

        
        public SpacesServices(IConfiguration configuration)
        {
            this.repository = new data.Repositories.SpacesRepository(configuration);
            this.mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<data.Entities.Space, View_Models.SpaceModel>().ReverseMap();
            }).CreateMapper();
        }

        public List<SpaceModel> GetSpacesByUserId(string uid)
        {
            var spaces = repository.GetSpacesByUserId(uid);
            if (spaces is null)
                return null;
            List<View_Models.SpaceModel> spaceModels = new List<View_Models.SpaceModel>();
            foreach (var s in spaces)
            {
                spaceModels.Add(mapper.Map<data.Entities.Space, View_Models.SpaceModel>(s));
            }
            return spaceModels;
        }

        public List<View_Models.SpaceModel> GetSpaces(string userId)
        {
            var spaces = repository.GetSpaces(userId);
            if (spaces is null) 
                return null;
            List<View_Models.SpaceModel> spaceModels = new List<View_Models.SpaceModel>();
            foreach(var s in spaces)
            {
                spaceModels.Add(mapper.Map<data.Entities.Space, View_Models.SpaceModel>(s));
            }
            return spaceModels;
        }

        public View_Models.SpaceModel GetSpaceById(int id)
        {
            var space = repository.GetSpaceById(id);
            return mapper.Map<data.Entities.Space, View_Models.SpaceModel>(space);
        }
        public View_Models.SpaceModel CreateSpace(View_Models.SpaceModel spaceModel)
        {
            var entitySpace = mapper.Map<View_Models.SpaceModel, data.Entities.Space>(spaceModel);
            entitySpace.DateCreated = System.DateTime.Now;
            repository.CreateSpace(entitySpace);
            return mapper.Map<data.Entities.Space, View_Models.SpaceModel>(entitySpace);
        }

        public data.Enums.HttpCode DeleteSpace(int spaceId, string userId)
        {
            return repository.DeleteSpace(spaceId, userId);
        }

        public View_Models.SpaceModel EditSpace(View_Models.SpaceModel spaceModel)
        {
            var entitySpace = mapper.Map<View_Models.SpaceModel, data.Entities.Space>(spaceModel);
            repository.EditSpace(entitySpace);
            return mapper.Map<data.Entities.Space, View_Models.SpaceModel>(entitySpace);
        }

       

    }
}
