using System;
using System.Collections.Generic;

namespace Lab2
{
    public class Series
    {
        private List<Number> NumberList { get; } = new List<Number>();

        public int Count => NumberList.Count;

        private delegate void SeriesEventHandler(object sender, string info);

        private event SeriesEventHandler Added;
        private event SeriesEventHandler Removed;
        private event SeriesEventHandler Cleared;

        public Series()
        {
            var onEventTriggered = new SeriesEventHandler((sender, info) => Console.WriteLine(info));
            Added += onEventTriggered;
            Removed += onEventTriggered;
            Cleared += onEventTriggered;
        }

        public void Add(Number number)
        {
            NumberList.Add(number);
            Added?.Invoke(this, $"Added {number} to series");
        }

        public void Remove(Number number)
        {
            NumberList.Remove(number);
            Removed?.Invoke(this, $"Removed {number} from series");
        }

        public void RemoveAt(int index)
        {
            NumberList.RemoveAt(index);
            Removed?.Invoke(this, $"Removed number at index #{index} from series");
        }

        public void Clear()
        {
            NumberList.Clear();
            Cleared?.Invoke(this, "Cleared series");
        }

        protected bool Equals(Series other)
        {
            return NumberList.Equals(other.NumberList);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Series)obj);
        }

        public override int GetHashCode()
        {
            return NumberList.GetHashCode();
        }

        public static bool operator ==(Series left, Series right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Series left, Series right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            var str = $"Series of {Count} Numbers:\n";
            var i = 0;
            foreach (var number in NumberList)
            {
                i++;
                str += $"\t{i}. {number}\n";
            }

            return str;
        }

        public Series DeepCopy()
        {
            var series = new Series();
            foreach (var number in NumberList)
            {
                series.NumberList.Add(number);
            }

            return series;
        }
    }
}