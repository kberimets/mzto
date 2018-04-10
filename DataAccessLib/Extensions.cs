using System.Collections.Generic;
using System.Linq;
using Common;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Mzto.DAL
{
    internal static class Extensions
    {
        static Extensions()
        {
            Mapper.Initialize
            (
                cfg =>
                {
                    cfg.CreateMap<Domain, DomainDto>();

                    cfg.CreateMap<PowerCenter, PowerCenterDto>();

                    cfg.CreateMap<Parameter, ParameterDto>()
                       .ForMember(dest => dest.OikCategory, opt => opt.MapFrom(src => src.OikCategoryId))
                       .ForMember(dest => dest.MztoType, opt => opt.MapFrom(src => src.TypeId));
                }
            );
        }

        internal static IEnumerable<DomainDto> AsDtoWithDependencies(this IEnumerable<Domain> domainDb, MztoContext context)
        {
            return domainDb                
                .Select(domain => domain.AsDtoWithDependencies(context))
                .ToArray();
        }

        internal static DomainDto AsDtoWithDependencies(this Domain domainDb, MztoContext context)
        {
            var domain = Mapper.Map<DomainDto>(domainDb);

            domain.PowerCenters = context.PowerCenters
                .Where(powerCenter => powerCenter.DomainId == domainDb.Id)
                .AsDtoWithDependencies(context)
                .ToArray();

            return domain;
        }

        internal static IEnumerable<PowerCenterDto> AsDtoWithDependencies(this IEnumerable<PowerCenter> powerCenterDb, MztoContext context)
        {
            return powerCenterDb
                .Select(powerCenter => powerCenter.AsDtoWithDependencies(context))
                .ToArray();
        }

        internal static PowerCenterDto AsDtoWithDependencies(this PowerCenter powerCenterDb, MztoContext context)
        {
            var powerCenter = Mapper.Map<PowerCenterDto>(powerCenterDb);

            powerCenter.Parameters = context.Parameters
                .Where(parameter => parameter.PowerCenterId == powerCenterDb.Id)
                .AsDto(context)
                .ToArray();

            return powerCenter;
        }

        internal static IEnumerable<ParameterDto> AsDto(this IEnumerable<Parameter> parameterDb, MztoContext context)
        {
            return parameterDb
                .Join(context.ParameterTypes,
                      parameter => parameter.TypeId,
                      parameterType => parameterType.Id,
                      (parameter, parameterType) => new ParameterDto
                      {
                          Id = parameter.Id,
                          OikId = parameter.OikId,
                          OikCategory = (Common.OikCategory)parameter.OikCategoryId,
                          MztoType = (MztoType)parameter.TypeId,
                          Description = parameterType.Description
                      }
                )
                .ToArray();
        }

        internal static ParameterDto AsDto(this Parameter parameterDb)
        {
            return Mapper.Map<ParameterDto>(parameterDb);
        }
    }
}
