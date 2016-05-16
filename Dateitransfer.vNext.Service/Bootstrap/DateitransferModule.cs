using AutoMapper;
using Ninject.Modules;

namespace Dateitransfer.vNext.Service.Bootstrap
{
    public class DateitransferModule : NinjectModule
    {
        public override void Load()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Dateitransfer.vNext.Lib.Model.Input, Dateitransfer.vNext.Api.Dto.Input>();
                cfg.CreateMap<Dateitransfer.vNext.Lib.Model.Output, Dateitransfer.vNext.Api.Dto.Output>();
                cfg.CreateMap<Dateitransfer.vNext.Lib.Model.Job, Dateitransfer.vNext.Api.Dto.Job>();
            });

            Bind<MapperConfiguration>().ToConstant(mapperConfig).InSingletonScope();
            Bind<Dateitransfer.vNext.Lib.Service.JobService>().ToSelf();
            Bind<Dateitransfer.vNext.Lib.Data.DateitransferContext>().ToSelf();
        }
    }
}
