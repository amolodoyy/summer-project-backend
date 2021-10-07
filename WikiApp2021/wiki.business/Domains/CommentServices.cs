using System;
using System.Collections.Generic;
using wiki.business.View_Models;
using wiki.data.Enums;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Linq;
using wiki.data.Entities;

namespace wiki.business.Domains
{
    public class CommentServices : ICommentServices
    {
        private readonly data.Repositories.CommentRepository repository;
        private readonly IMapper mapper;

        public CommentServices(IConfiguration configuration)
        {
            this.repository = new data.Repositories.CommentRepository(configuration);
            this.mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<data.Entities.Comment, View_Models.CommentModel>().ReverseMap();
            }).CreateMapper();
        }
        public List<CommentModel> GetUserComments(string userId)
        {
            var comments = repository.GetUserComments(userId);
            if (comments is null)
                return null;
            List<CommentModel> commentModels = new List<CommentModel>();
            commentModels = comments.Select(p => mapper.Map<data.Entities.Comment, View_Models.CommentModel>(p)).ToList();
            return commentModels;
        }

        public List<CommentModel> GetCommentById(int pagesid)
        {
            var comments = repository.GetCommentById(pagesid);
            if (comments is null)
                return null;
            List<CommentModel> commentModels = new List<CommentModel>();
            commentModels = comments.Select(p => mapper.Map<data.Entities.Comment, View_Models.CommentModel>(p)).ToList();
            return commentModels;
        }
        public CommentModel CreateComment(CommentModel commentModel)
        {
            var entityComment = mapper.Map<CommentModel, data.Entities.Comment>(commentModel);
            entityComment.DateCreated = DateTime.Now;
            repository.CreateComment(entityComment);
            return mapper.Map<data.Entities.Comment, CommentModel>(entityComment);
        }

        public HttpCode DeleteComment(int id, string userId)
        {
           

            return repository.DeleteComment(id, userId);
        }

        public CommentModel EditComment(CommentModel commentModel, string userId)
        {
            var entityComment = mapper.Map<View_Models.CommentModel, data.Entities.Comment>(commentModel);
            if (commentModel.UserId == userId)
            {
                repository.EditComment(entityComment);
                return mapper.Map<data.Entities.Comment, View_Models.CommentModel>(entityComment);
            }
            else return null;
        }

    }
}
