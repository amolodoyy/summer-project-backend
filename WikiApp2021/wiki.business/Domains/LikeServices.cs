using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using wiki.business.View_Models;
using wiki.data.Enums;

namespace wiki.business.Domains
{
    public class LikeServices : ILikeServices
    {
        private readonly data.Repositories.LikeRepository repository;
        private readonly IMapper mapper;
        public LikeServices(IConfiguration configuration)
        {
            this.repository = new data.Repositories.LikeRepository(configuration);
            this.mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<data.Entities.Like, View_Models.LikeModel>().ReverseMap();
            }).CreateMapper();
        }
        public List<LikeModel> GetPageLikes(int pageId)
        {
            return repository.GetPageLikes(pageId)?.Select(l => mapper.Map<data.Entities.Like, View_Models.LikeModel>(l))?.ToList();
        }
        public HttpCode CreateLike(int pageId, string userId)
        {
            return repository.CreateLike(pageId, userId);
        }

        public HttpCode RemoveLike(int pageId, string userId)
        {
            return repository.RemoveLike(pageId, userId);
        }
        public bool IsLiked(int pageId, string userId)
        {
            return repository.IsLiked(pageId, userId);
        }
    }
}
