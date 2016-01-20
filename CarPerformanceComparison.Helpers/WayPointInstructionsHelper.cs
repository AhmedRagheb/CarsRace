using System;
using System.Collections.Generic;
using System.Linq;
using CarPerformanceComparison.Data;

namespace CarPerformanceComparison.Helpers
{
    public static class WayPointInstructionsHelper
    {
        private const double FirstWayPointValue = 5.0;
        private const double LastWayPointValue = 0.0;
        private const int MinWayPointValue = 1;
        private const int MaxWayPointValue = 100;
        
        /// <summary>
        /// Get random waypoint instruction and value assuming that first waypoint is the start point of Race 
        /// and last waypoint is the end point of Race
        /// </summary>
        /// <param name="waypoint"></param>
        /// <param name="allCheckpoints"></param>
        /// <returns></returns>
        public static WaypointInstruction GetWayPointInstruction(Waypoint waypoint, List<Waypoint> allCheckpoints)
        {
            if (waypoint == allCheckpoints.First())
            {
                return new WaypointInstruction(Instructions.SetSpeed, FirstWayPointValue);
            }
            
            if (waypoint == allCheckpoints.Last())
            {
                return new WaypointInstruction(Instructions.SetSpeed, LastWayPointValue);
            }


            var instruction = GetRandomInstruction();
            var value = GetRandomInstructionValue(instruction);
            return new WaypointInstruction(instruction, value);
        }

        private static Instructions GetRandomInstruction()
        {
            var values = Enum.GetValues(typeof(Instructions));
            var random = new Random();
            var randomInstruction = (Instructions)values.GetValue(random.Next(values.Length));
            return randomInstruction;
        }

        private static double GetRandomInstructionValue(Instructions instructions)
        {
            var value = 0;
            var random = new Random();

            switch (instructions)
            {
                case Instructions.None:
                    value = 0;
                    break;

                case Instructions.SetSpeed:
                case Instructions.SpeedUpPercent:
                case Instructions.SlowDownPercent:
                    value = random.Next(MinWayPointValue, MaxWayPointValue);
                    break;
            }

            return value;
        }
    }
}
