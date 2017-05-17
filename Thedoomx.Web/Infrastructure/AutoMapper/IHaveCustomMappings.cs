using AutoMapper;

namespace Thedoomx.Web.Infrastructure.AutoMapper
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
