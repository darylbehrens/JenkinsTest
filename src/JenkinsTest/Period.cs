using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JenkinsTest
{
    public class Period
    {
        public DateTime Start { get; private set; }
        public DateTime Finish { get; private set; }
        public double Minutes { get { return (Finish - Start).TotalMinutes; } }

        protected Period(DateTime start, DateTime finish)
        {
            Start = start;
            Finish = finish;
        }

        public static Period Create(DateTime start, DateTime finish)
        {
            return new Period(start, finish);
        }

        public override string ToString()
        {
            return String.Format("{0:yyyyMMddTHHmmss}-{1:yyyyMMddTHHmmss}", Start, Finish);
        }
    }
}
