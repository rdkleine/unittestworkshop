using AutoMapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<LogicService.Model.Employee, LogicService.Dto.Employee>();
        CreateMap<LogicService.Dto.Employee, LogicService.Model.Employee>();
    }
}
