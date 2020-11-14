using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo commanderRepo, IMapper mapper)
        {
            _repository = commanderRepo;  // Register IRepo ad Configuration
            _mapper = mapper; // Register IMapper ad Configuration
        }

        //GET api/commands/
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            //Map data form model SQL to ViewData before response
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        //GET api/commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            //Map data form model SQL to ViewData before response
            var commandItem = _repository.GetCommandById(id);
            if (commandItem == null) return NotFound();

            return Ok(_mapper.Map<CommandReadDto>(commandItem));
        }

        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChange(); // Transfer to actual change

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
            //C1: return Ok(commandReadDto);

            //C2: Redirect to another API
            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
        }

        //PUT api/commands
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdate)
        {
            var commandModelFormRepo = _repository.GetCommandById(id);

            if (commandModelFormRepo == null)
            {
                return NotFound();
            }

            // Another way to map
            _mapper.Map(commandUpdate, commandModelFormRepo);

            //Due to  commandModelFromRepo has already change after map above
            // But Update do nothing in Inheritent Interface (F12 TO CHECK)
            _repository.UpdateCommand(commandModelFormRepo);

            _repository.SaveChange();

            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {

            Command cmd = _repository.GetCommandById(id);
            if (cmd == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(cmd);
            _repository.SaveChange();

            return NoContent();
        }
    }
}