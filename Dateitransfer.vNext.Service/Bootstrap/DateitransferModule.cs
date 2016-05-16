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
                cfg.CreateMap<Dateitransfer.vNext.Lib.Model.Input, Dateitransfer.vNext.Service.Dto.Input>();
                cfg.CreateMap<Dateitransfer.vNext.Lib.Model.Output, Dateitransfer.vNext.Service.Dto.Output>();
                cfg.CreateMap<Dateitransfer.vNext.Lib.Model.Job, Dateitransfer.vNext.Service.Dto.Job>();
            });

            Bind<MapperConfiguration>().ToConstant(mapperConfig).InSingletonScope();
            Bind<Dateitransfer.vNext.Lib.Service.JobService>().ToSelf();
        }
    }
}
