using System.Collections.Generic;
using Commander.Models;
using System.Linq;
using System;

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int Id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id == Id);
        }

        public bool SaveChange()
        {
            //Actual SAVE in SQL DB 
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command cmd)
        {
            //Do nothing because we will change (ngầm định do biến con trỏ)
            //in Controller class by IMapping
        }
    }
}