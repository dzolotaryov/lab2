using System;

namespace Lab2
{
    public class Real : Number
    {
        public double Value { get; }

        public Real(double value)
        {
            Value = value;
        }

        public override Number Add(Number other)
        {
            return new Real(Value + ((Real)other).Value);
        }

        public override Number Substract(Number other)
        {
            return new Real(Value - ((Real)other).Value);
        }

        public override Number Multiply(Number other)
        {
            return new Real(Value * ((Real)other).Value);
        }

        public override Number Divide(Number other)
        {
            var val = (Real)other;
            if (val.Value == 0) throw new DivideByZeroException("Trying to divide by 0");
            return new Real(Value / val.Value);
        }

        protected bool Equals(Real other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Real)obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(Real left, Real right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Real left, Real right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"Real({Value})";
        }

        public Integer ToInteger()
        {
            return new Integer((int)Value);
        }
    }
}