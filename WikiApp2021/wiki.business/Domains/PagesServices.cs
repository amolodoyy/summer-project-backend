using System;
using System.Collections.Generic;
using wiki.business.View_Models;
using wiki.data.Enums;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace wiki.business.Domains
{
    public class PagesServices : IPagesServices
    {
        private readonly data.Repositories.PagesRepository repository;
        private readonly IMapper mapper;
        public PagesServices(IConfiguration configuration)
        {
            this.repository = new data.Repositories.PagesRepository(configuration);
            this.mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<data.Entities.Page, View_Models.PageModel>().ReverseMap();
            }).CreateMapper();
        }
        public List<PageModel> GetUserPages(string userId)
        {
            var pages = repository.GetUserPages(userId);
            if (pages is null)
                return null;
            List<PageModel> pageModels = new List<PageModel>();

            pageModels = pages.Select(p => mapper.Map<data.Entities.Page, View_Models.PageModel>(p)).ToList();

            return pageModels;
        }     
    
        public PageModel GetPageById(int id)
        {
            var page = repository.GetPageById(id);
            return mapper.Map<data.Entities.Page, PageModel>(page);
        }
        public PageModel CreatePage(PageModel pageModel)
        {
            var entityPage = mapper.Map<PageModel, data.Entities.Page>(pageModel);
            entityPage.DateCreated = DateTime.Now;
            repository.CreatePage(entityPage);
            return mapper.Map<data.Entities.Page, PageModel>(entityPage);
        }

        public HttpCode DeletePage(int id, string userId)
        {
            return repository.DeletePage(id, userId);
        }

        public PageModel EditPage(PageModel pageModel)
        {
            var entityPage = mapper.Map<View_Models.PageModel, data.Entities.Page>(pageModel);
            repository.EditPage(entityPage);
            return mapper.Map<data.Entities.Page, View_Models.PageModel>(entityPage);
        }
        public HttpCode EditPageBody(string body, int pageId)
        {
            return repository.EditPageBody(body, pageId);
        }

        public List<PageModel> GetPages(string userId)
        {
            var pages = repository.GetPages(userId);
            if (pages is null)
                return null;
            List<PageModel> pageModels = new List<PageModel>();
            pageModels = pages.Select(p => mapper.Map<data.Entities.Page, View_Models.PageModel>(p)).ToList();
            return pageModels;
        }
        public List<View_Models.PageModel> GetAllPages(string userId)
        {
            var pages = repository.GetAllPages(userId);
            if (pages is null)
                return null;
            List<PageModel> pageModels = new List<PageModel>();
            pageModels = pages.Select(p => mapper.Map<data.Entities.Page, View_Models.PageModel>(p)).ToList();
            return pageModels;
        }

        
    }
}
