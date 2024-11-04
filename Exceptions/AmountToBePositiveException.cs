using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountNUnit.Exceptions
{
    internal class AmountToBePositiveException:Exception
    {
        public AmountToBePositiveException(string message): base(message)
        {
            
        }
    }
}
