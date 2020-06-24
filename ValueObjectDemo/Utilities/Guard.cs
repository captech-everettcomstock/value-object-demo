using System;
using System.Diagnostics;

namespace ValueObjectDemo.Utilities
{
    public static class Guard
    {
        [DebuggerHidden]
        public static void Requires<TException>(bool expression, string message) where TException : Exception, new()
        {
            if (expression == true)
            {
                return;
            }

            var exception = (TException)Activator.CreateInstance(typeof(TException), message);

            throw exception;
        }

        [DebuggerHidden]
        public static void AgainstNull<T>(T value)
            where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
        }

        [DebuggerHidden]
        public static void AgainstNull<T>(T value, string paramName)
            where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        [DebuggerHidden]
        public static void AgainstNull<T>(T value, string paramName, string message)
            where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName, message);
            }
        }

        [DebuggerHidden]
        public static void AgainstNull<T>(T? value)
            where T : struct
        {
            if (!value.HasValue)
            {
                throw new ArgumentNullException();
            }
        }

        [DebuggerHidden]
        public static void AgainstNull<T>(T? value, string paramName)
            where T : struct
        {
            if (!value.HasValue)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        [DebuggerHidden]
        public static void AgainstNull<T>(T? value, string paramName, string message)
            where T : struct
        {
            if (!value.HasValue)
            {
                throw new ArgumentNullException(paramName, message);
            }
        }

        [DebuggerHidden]
        public static void AgainstNull(string value)
        {
            if (value.IsNull())
            {
                throw new ArgumentNullException();
            }
        }

        [DebuggerHidden]
        public static void AgainstNull(string value, string paramName)
        {
            if (value.IsNull())
            {
                throw new ArgumentNullException(paramName);
            }
        }

        [DebuggerHidden]
        public static void AgainstNull(string value, string paramName, string message)
        {
            if (value.IsNull())
            {
                throw new ArgumentNullException(paramName, message);
            }
        }

        [DebuggerHidden]
        public static void AgainstEmpty(string value)
        {
            if (value.IsEmpty())
            {
                throw new ArgumentException("string value must not be empty");
            }
        }

        [DebuggerHidden]
        public static void AgainstEmpty(string value, string paramName)
        {
            if (value.IsEmpty())
            {
                throw new ArgumentException("string value must not be empty", paramName);
            }
        }

        [DebuggerHidden]
        public static void AgainstEmpty(string value, string paramName, string message)
        {
            if (value.IsEmpty())
            {
                throw new ArgumentException(message, paramName);
            }
        }

        [DebuggerHidden]
        public static void GreaterThan<T>(T lowerLimit, T value)
            where T : IComparable<T>
        {
            if (value.CompareTo(lowerLimit) <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        [DebuggerHidden]
        public static void GreaterThan<T>(T lowerLimit, T value, string paramName)
            where T : IComparable<T>
        {
            if (value.CompareTo(lowerLimit) <= 0)
            {
                throw new ArgumentOutOfRangeException(paramName);
            }
        }

        [DebuggerHidden]
        public static void GreaterThan<T>(T lowerLimit, T value, string paramName, string message)
            where T : IComparable<T>
        {
            if (value.CompareTo(lowerLimit) <= 0)
            {
                throw new ArgumentOutOfRangeException(paramName, message);
            }
        }


        [DebuggerHidden]
        public static void LessThan<T>(T upperLimit, T value)
            where T : IComparable<T>
        {
            if (value.CompareTo(upperLimit) >= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        [DebuggerHidden]
        public static void LessThan<T>(T upperLimit, T value, string paramName)
            where T : IComparable<T>
        {
            if (value.CompareTo(upperLimit) >= 0)
            {
                throw new ArgumentOutOfRangeException(paramName);
            }
        }

        [DebuggerHidden]
        public static void LessThan<T>(T upperLimit, T value, string paramName, string message)
            where T : IComparable<T>
        {
            if (value.CompareTo(upperLimit) >= 0)
            {
                throw new ArgumentOutOfRangeException(paramName, message);
            }
        }

        [DebuggerHidden]
        public static void IsTrue<T>(Func<T, bool> condition, T target)
        {
            if (!condition(target))
            {
                throw new ArgumentException("condition was not true");
            }
        }

        [DebuggerHidden]
        public static void IsTrue<T>(Func<T, bool> condition, T target, string paramName)
        {
            if (!condition(target))
            {
                throw new ArgumentException("condition was not true", paramName);
            }
        }

        [DebuggerHidden]
        public static void IsTrue<T>(Func<T, bool> condition, T target, string paramName, string message)
        {
            if (!condition(target))
            {
                throw new ArgumentException(message, paramName);
            }
        }

        [DebuggerHidden]
        public static bool IsNull(this object instance)
        {
            return instance == null;
        }

        [DebuggerHidden]
        public static bool IsEmpty(this string value)
        {
            return value != null && string.IsNullOrEmpty(value);
        }

        [DebuggerHidden]
        public static T IsTypeOf<T>(object instance)
        {
            AgainstNull(instance);

            if (instance is T)
            {
                return (T)instance;
            }

            throw new ArgumentException($"{ instance.GetType().Name } is not an instance of type { typeof(T).Name }.");
        }
    }
}
