using AutoMapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<LogicService.Model.Employee, LogicService.Dto.Employee>();
        CreateMap<LogicService.Model.Address, LogicService.Dto.Address>();
        CreateMap<LogicService.Dto.Employee, LogicService.Model.Employee>();
        CreateMap<LogicService.Dto.Address, LogicService.Model.Address>();
    }
}
