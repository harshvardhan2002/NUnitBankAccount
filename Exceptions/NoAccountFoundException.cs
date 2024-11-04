using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountNUnit.Exceptions
{
    internal class NoAccountFoundException:Exception
    {
        public NoAccountFoundException(string message) : base(message) { }
        
    }
}
