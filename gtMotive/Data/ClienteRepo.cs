using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gtMotive.Models;

namespace gtMotive.Data
{
    public class ClienteRepo : IClienteRepo
    {

        private readonly AppDbContext _context;

        public ClienteRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente));
            }
            _context.Clientes.Add(cliente);
        }

        public IEnumerable<Cliente> GetAllClientes()
        {
            return _context.Clientes.ToList();
        }

        public Cliente GetClienteById(int id)
        {
            return _context.Clientes.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}