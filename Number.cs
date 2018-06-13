using System;

namespace Lab2
{
    public abstract class Number
    {
        public virtual Number Add(Number other)
        {
            throw new NotImplementedException();
        }

        public virtual Number Substract(Number other)
        {
            throw new NotImplementedException();
        }

        public virtual Number Multiply(Number other)
        {
            throw new NotImplementedException();
        }

        public virtual Number Divide(Number other)
        {
            throw new NotImplementedException();
        }

        public static Number operator +(Number a, Number b)
        {
            return a.Add(b);
        }

        public static Number operator -(Number a, Number b)
        {
            return a.Substract(b);
        }

        public static Number operator *(Number a, Number b)
        {
            return a.Multiply(b);
        }

        public static Number operator /(Number a, Number b)
        {
            return a.Divide(b);
        }

        public static bool operator ==(Number left, Number right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Number left, Number right)
        {
            return !Equals(left, right);
        }
    }
}