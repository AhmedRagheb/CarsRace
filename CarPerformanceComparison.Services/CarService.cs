using System.Linq;
using CarPerformanceComparison.Contracts;
using CarPerformanceComparison.Data;
using CarPerformanceComparison.Helpers;

namespace CarPerformanceComparison.Services
{
    public class CarService : ICar
    {
        public string Name { get; private set; }
        public double CurrentSpeed { get; private set; }
        public double MaxSpeed { get; private set; }
        public ConsumptionAtSpeed LowSpeedConsumption { get; private set; }
        public ConsumptionAtSpeed HighSpeedConsumption { get; private set; }

        public CarService(string name, ConsumptionAtSpeed lowSpeedConsumption, ConsumptionAtSpeed highSpeedConsumption, double maxSpeed)
        {
            Name = name;
            LowSpeedConsumption = lowSpeedConsumption;
            HighSpeedConsumption = highSpeedConsumption;
            MaxSpeed = maxSpeed;
        }

        public double GetAverageFuelConsumption(IRace Race)
        {
            var averageFuelConsumption = 0.0;
            for (int i=0; i< Race.Waypoints.Count(); i++)
            {
                // Check Instruction if not null in case value sent from Unit testing
                var instruction = Race.Waypoints.ElementAt(i).Instruction ??
                                  WayPointInstructionsHelper.GetWayPointInstruction(Race.Waypoints.ElementAt(i),
                                                                                    Race.Waypoints.ToList());
                SetCurrentSpeed(instruction);
                var distance = 0.0;
                
                // no need for calculate distance in last wayoint assuming that last point is Race end point 
                if(i != Race.Waypoints.Count() - 1)
                    distance = Race.GetDistanceForLeg(Race.Waypoints.ElementAt(i).Position,
                                         Race.Waypoints.ElementAt(i + 1).Position);

                // What If current Speed not in low or high range How to calculate Consumption ??
                if (LowSpeedConsumption.Range.IsWithinRange(this.CurrentSpeed))
                    averageFuelConsumption += LowSpeedConsumption.Consumption * distance;
                else
                    if (HighSpeedConsumption.Range.IsWithinRange(this.CurrentSpeed))
                        averageFuelConsumption += HighSpeedConsumption.Consumption * distance;
            }

            return averageFuelConsumption;
        }


        private void SetCurrentSpeed(WaypointInstruction instruction)
        {
            switch (instruction.Instruction)
            {
                case Instructions.None:
                    this.CurrentSpeed = this.CurrentSpeed;
                    break;
                    
                case Instructions.SetSpeed:
                    this.CurrentSpeed = instruction.Value;
                    break;
                    
                case Instructions.SpeedUpPercent:
                    var speedUpValue = (this.CurrentSpeed*instruction.Value)/100;
                    var speedAfterUp = this.CurrentSpeed + speedUpValue;
                    this.CurrentSpeed = speedAfterUp <= this.MaxSpeed ? speedAfterUp : this.CurrentSpeed;
                    break;
                    
                case Instructions.SlowDownPercent:
                    var slowDownValue = (this.CurrentSpeed * instruction.Value) / 100;
                    var speedAfterDown = this.CurrentSpeed - slowDownValue;
                    this.CurrentSpeed = speedAfterDown;
                    break;
            }
        }


    }

}
