using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //Source --> Target
            CreateMap<Command, CommandReadDto>();
            //Client data -->Source
            CreateMap<CommandCreateDto, Command>();
            //Client Update --> Source
            CreateMap<CommandUpdateDto, Command>();
        }
    }
}