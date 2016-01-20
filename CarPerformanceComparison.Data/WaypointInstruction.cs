using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPerformanceComparison.Data
{
    public class WaypointInstruction
    {
        public Instructions Instruction { get; private set; }
        public double Value { get; private set; }

        public WaypointInstruction(Instructions instr, double value)
        {
            value.AssertNotNegative();
            
            this.Instruction = instr;
            this.Value = value;
        }
    }
}
