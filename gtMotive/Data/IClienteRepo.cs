using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gtMotive.Models;

namespace gtMotive.Data
{
    public interface IClienteRepo
    {
        bool SaveChanges();

        IEnumerable<Cliente> GetAllClientes();

        Cliente GetClienteById(int id);
        void Create(Cliente cliente);
    }
}