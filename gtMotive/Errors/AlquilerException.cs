using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gtMotive.Errors
{
    public class AlquilerException : Exception
    {
        public AlquilerException(string message):base(message){}
    }
}