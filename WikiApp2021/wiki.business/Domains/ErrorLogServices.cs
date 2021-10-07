using AutoMapper;
using Microsoft.Extensions.Configuration;
using wiki.business.View_Models;

namespace wiki.business.Domains
{
    public class ErrorLogServices : IErrorLogServices
    {
        private readonly data.Repositories.ErrorLogRepository repository;
        private readonly IMapper mapper;

        public ErrorLogServices(IConfiguration configuration)
        {
            this.repository = new data.Repositories.ErrorLogRepository(configuration);
            this.mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<data.Entities.ErrorLog, View_Models.ErrorLogModel>().ReverseMap();
            }).CreateMapper();
        }

        public View_Models.ErrorLogModel CreateErrorLog(View_Models.ErrorLogModel errorLog)
        {
            var entityError = mapper.Map<ErrorLogModel, data.Entities.ErrorLog>(errorLog);
            repository.CreateErrorLog(entityError);
            return mapper.Map<data.Entities.ErrorLog, ErrorLogModel>(entityError);
        }

        
    }
}