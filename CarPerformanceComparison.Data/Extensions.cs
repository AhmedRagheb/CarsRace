using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarPerformanceComparison.Data
{
    public static class Extensions
    {
        public static void AssertNotEmpty<T>(this T targetObject, [CallerFilePath] string file = null, [CallerLineNumber] int? lineNumber = null, [CallerMemberName] string caller = null)
                            where T : class, IEnumerable
        {
            if (targetObject == null || !targetObject.GetEnumerator().MoveNext())
            {

                throw new ArgumentNullException(caller, string.Format("{0} must be a non empty enumerable at {1}, line number {2} in file {3} ", typeof(T).Name, caller, lineNumber, Path.GetFileName(file)));
            }
        }

        public static void AssertNotNull<T>(this T targetObject, [CallerFilePath] string file = null, [CallerLineNumber] int? lineNumber = null, [CallerMemberName] string caller = null)
                            where T : class
        {
            if (targetObject == null)
            {

                throw new ArgumentNullException(caller, string.Format("{0} is required at {1}, line number {2} in file {3} ", typeof(T).Name, caller, lineNumber, Path.GetFileName(file)));
            }
        }

        public static void AssertEquals<T>(this T targetObject, T comparedTo, [CallerFilePath] string file = null, [CallerLineNumber] int? lineNumber = null, [CallerMemberName] string caller = null)
                            where T : 
          IComparable<T>
        {
            if (targetObject.CompareTo(comparedTo) != 0)
            {

                throw new ArgumentNullException(caller, string.Format("{4} must be {0} at {1}, line number {2} in file {3} ", comparedTo, caller, lineNumber, Path.GetFileName(file), targetObject.ToString()));
            }
        }

        public static void AssertLessThan<T>(this T targetObject, T comparedTo, [CallerFilePath] string file = null, [CallerLineNumber] int? lineNumber = null, [CallerMemberName] string caller = null)
                            where T :  
          IComparable<T>
        {
            if (targetObject.CompareTo(comparedTo) >= 0)
            {

                throw new ArgumentNullException(caller, string.Format("{4} must be < {0} at {1}, line number {2} in file {3} ", comparedTo, caller, lineNumber, Path.GetFileName(file), targetObject.ToString()));
            }
        }

        public static void AssertLessThanOrEqualTo<T>(this T targetObject, T comparedTo, [CallerFilePath] string file = null, [CallerLineNumber] int? lineNumber = null, [CallerMemberName] string caller = null)
                            where T :
          IComparable<T>
        {
            if (targetObject.CompareTo(comparedTo) > 0)
            {

                throw new ArgumentNullException(caller, string.Format("{4} must be <= {0} at {1}, line number {2} in file {3} ", comparedTo, caller, lineNumber, Path.GetFileName(file), targetObject.ToString()));
            }
        }

        public static void AssertLargerThan<T>(this T targetObject, T comparedTo, [CallerFilePath] string file = null, [CallerLineNumber] int? lineNumber = null, [CallerMemberName] string caller = null)
                            where T :
          IComparable<T>
        {
            if (targetObject.CompareTo(comparedTo) <= 0)
            {

                throw new ArgumentNullException(caller, string.Format("{4} must be > {0} at {1}, line number {2} in file {3} ", comparedTo, caller, lineNumber, Path.GetFileName(file), targetObject.ToString()));
            }
        }

        public static void AssertLargerThanOrEqualTo<T>(this T targetObject, T comparedTo, [CallerFilePath] string file = null, [CallerLineNumber] int? lineNumber = null, [CallerMemberName] string caller = null)
                            where T :
          IComparable<T>
        {
            if (targetObject.CompareTo(comparedTo) < 0)
            {

                throw new ArgumentNullException(caller, string.Format("{4} must be >= {0} at {1}, line number {2} in file {3} ", comparedTo, caller, lineNumber, Path.GetFileName(file), targetObject.ToString()));
            }
        }

        public static void AssertPositive<T>(this T targetObject, [CallerFilePath] string file = null, [CallerLineNumber] int? lineNumber = null, [CallerMemberName] string caller = null)
                            where T : struct, 
          IComparable,
          IComparable<T>,
          IConvertible,
          IEquatable<T>,
          IFormattable
        {
            if (targetObject.CompareTo(0.0) <= 0)
            {

                throw new ArgumentNullException(caller, string.Format("Number must be > 0 at {0}, line number {1} in file {2} ",caller, lineNumber, Path.GetFileName(file)));
            }
        }

        public static void AssertNotNegative<T>(this T targetObject, [CallerFilePath] string file = null, [CallerLineNumber] int? lineNumber = null, [CallerMemberName] string caller = null)
                            where T : struct, 
          IComparable,
          IComparable<T>,
          IConvertible,
          IEquatable<T>,
          IFormattable
        {
            if (targetObject.CompareTo(0.0) < 0)
            {

                throw new ArgumentNullException(caller, string.Format("Number must be >= 0 at {0}, line number {1} in file {2} ", caller, lineNumber, Path.GetFileName(file)));
            }
        }

        public static void AssertNegative<T>(this T targetObject, [CallerFilePath] string file = null, [CallerLineNumber] int? lineNumber = null, [CallerMemberName] string caller = null)
                            where T : struct, 
          IComparable,
          IComparable<T>,
          IConvertible,
          IEquatable<T>,
          IFormattable
        {
            if (targetObject.CompareTo(0.0) >= 0)
            {

                throw new ArgumentNullException(caller, string.Format("Number must be < 0 at {0}, line number {1} in file {2} ", caller, lineNumber, Path.GetFileName(file)));
            }
        }

        public static void AssertNotNull<T>(this T? targetObject, [CallerFilePath] string file = null, [CallerLineNumber] int? lineNumber = null, [CallerMemberName] string caller = null)
                                 where T : struct
        {
            if (!targetObject.HasValue)
            {
                StackFrame fr = new StackFrame(1, true);
                StackTrace st = new StackTrace(fr);

                throw new ArgumentNullException(fr.GetMethod().Name + " is required");
            }
        }

        public static void AssertNotEmpty(this string stringTargetObj, [CallerFilePath] string file = null, [CallerLineNumber] int? lineNumber = null, [CallerMemberName] string caller = null)
        {
            if (string.IsNullOrWhiteSpace(stringTargetObj))
            {
                throw new ArgumentNullException(caller, string.Format("Non empty string is required at {0}, line number {1} in file {2} ", caller, lineNumber, Path.GetFileName(file)));
            }
        }

    }
}
