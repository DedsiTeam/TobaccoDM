using Mapster;
using MapsterMapper;

namespace TobaccoDMSystemManagement.Infrastructure.Utils
{
    public static class MapsterConfig
    {

        public static TDestination MapsterTo<TSource, TDestination>(TSource tSource) where TSource : class where TDestination : class => tSource.Adapt<TDestination>();

        public static List<TDestination> MapsterToList<TSource, TDestination>(List<TSource> sources) where TSource : class where TDestination : class => sources.Adapt<List<TDestination>>();

        public static List<TDestination> MapsterToList<TSource, TDestination>(List<TSource> sources, TypeAdapterConfig typeAdapterConfig) where TSource : class where TDestination : class
        {
            var mapper = new Mapper(typeAdapterConfig);
            return mapper.Map<List<TDestination>>(sources);
        }
    }
}
