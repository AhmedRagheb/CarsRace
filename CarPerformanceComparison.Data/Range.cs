using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarPerformanceComparison.Data
{
    public class Range {
        public static bool Within(double expected, double value, double delta)
        {
            if (double.IsNaN(expected) && double.IsNaN(value))
                return true;
            return value >= expected - delta && value <= expected + delta;
        }

        public static bool Within(double? expected, double? value, double delta)
        {
            if (expected.HasValue && value.HasValue)
                return Range.Within(expected.Value, value.Value, delta);
            else
                return expected.HasValue == value.HasValue;
        }
    }

    public class Range<T> where T : IComparable<T>
    {
        public T Min { get; set; }
        public T Max { get; set; }

        public Range()
        {

        }

        public Range(T min, T max)
        {
            min.AssertLessThanOrEqualTo(max);
            
            this.Min = min;
            this.Max = max;
        }

        public bool IsWithinRange(T value, bool lowerBoundLargerThan = false, bool upperBoundSmallerThan = false, bool checkLowerRange = true, bool checkUpperRange = true)
        {

            if (!lowerBoundLargerThan && !upperBoundSmallerThan)
            {
                return (!checkLowerRange || value.CompareTo(Min) >= 0) && (!checkUpperRange || value.CompareTo(Max) <= 0);
            }
            else if (lowerBoundLargerThan && !upperBoundSmallerThan) { 
                return value.CompareTo(Min) > 0 && value.CompareTo(Max) <= 0;
            }
            else if (!lowerBoundLargerThan && upperBoundSmallerThan)
            {
                return value.CompareTo(Min) >= 0 && value.CompareTo(Max) < 0;
            }
            else {
                return value.CompareTo(Min) > 0 && value.CompareTo(Max) < 0;
            }
        }

        public static bool Within(double? expected, double? value, double delta)
        {
            if (expected.HasValue && value.HasValue)
                return Range.Within(expected.Value, value.Value,delta);
            else
                return expected.HasValue == value.HasValue;
        }

    }
}
