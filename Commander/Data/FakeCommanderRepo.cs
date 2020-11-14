using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class FakeCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {

        }

        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>{
                new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle and Pan" },
                new Command { Id = 1, HowTo = "Cut bread", Line = "Get a knife", Platform = "Knife and chopping board" },
                new Command { Id = 2, HowTo = "Make cup of tea", Line = "Place teabag in cup", Platform = "Kettle and cup" }
            };

            return commands;
        }
        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle and Pan" };
        }

        public bool SaveChange()
        {
            return false;
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}