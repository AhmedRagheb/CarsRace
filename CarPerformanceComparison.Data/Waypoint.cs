using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarPerformanceComparison.Data
{
    public class Waypoint 
    {
        private Position _position;
        private WaypointInstruction _instruction;

        public Waypoint(Position pos, WaypointInstruction instr)
        {
            pos.AssertNotNull();
            instr.AssertNotNull();

            _position = pos;
            _instruction = instr;
        }

        public Position Position
        {
            get { return _position; }
        }

        public WaypointInstruction Instruction
        {
            get { return _instruction; }
            set {
                value.AssertNotNull();
                _instruction = value; 
            }
        }
    }
}
