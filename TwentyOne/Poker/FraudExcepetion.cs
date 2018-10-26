using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class FraudExcepetion : Exception
    {
        public FraudExcepetion()
            : base() { }
        public FraudExcepetion(string message)
            : base(message) { }
    }
}
