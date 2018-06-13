using System;

namespace Lab2
{
    public class Integer : Number
    {
        public int Value { get; }

        public Integer(int value)
        {
            Value = value;
        }

        public override Number Add(Number other)
        {
            return new Integer(Value + ((Integer)other).Value);
        }

        public override Number Substract(Number other)
        {
            return new Integer(Value - ((Integer)other).Value);
        }

        public override Number Multiply(Number other)
        {
            return new Integer(Value * ((Integer)other).Value);
        }

        public override Number Divide(Number other)
        {
            var val = (Integer)other;
            if (val.Value == 0) throw new DivideByZeroException("Trying to divide by 0");
            return new Integer(Value / val.Value);
        }

        protected bool Equals(Integer other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Integer)obj);
        }

        public override int GetHashCode()
        {
            return Value;
        }

        public static bool operator ==(Integer left, Integer right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Integer left, Integer right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"Integer({Value})";
        }

        public Real ToReal()
        {
            return new Real(Value);
        }
    }
}