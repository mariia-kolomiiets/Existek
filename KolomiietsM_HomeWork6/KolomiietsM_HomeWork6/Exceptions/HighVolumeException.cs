using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork6.Exceptions
{
    public class HighVolumeException : Exception
    {
        public HighVolumeException(string message) : base(message)
        {

        }
    }
}
