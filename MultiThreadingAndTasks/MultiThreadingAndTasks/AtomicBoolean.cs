using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadingAndTasks
{
    public class AtomicBoolean
    {
        private int backValue = 0;

        public AtomicBoolean(bool value)
        {
            backValue = value ? 1 : 0;
        }

        public bool Value
        {
            get
            {
                return Interlocked.CompareExchange(ref backValue, 1, 1) == 1; // Return whatever is in backValue
            }

            set
            {
                if(value)
                {
                    Interlocked.CompareExchange(ref backValue, 1, 0); // Replaces backValue value with 1, if value is true and backValue originally was 0
                }
                else
                {
                    Interlocked.CompareExchange(ref backValue, 0, 1); // Replaces backValue value with 0, if value is false and backValue originally was 1
                }
            }
        }
    }
}
