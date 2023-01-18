using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gtMotive.Errors
{
    public class VehiculoException : Exception
    {
        public VehiculoException(string message):base(message){}
    }
}