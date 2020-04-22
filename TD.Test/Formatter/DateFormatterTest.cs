using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TD.Formatter;

namespace TD.Test.Formatter
{
    public class DateFormatterTest
    {
        [Test]
        public void DateFormatTest()
        {
            var date = DateTime.Now;
            Debug.WriteLine($"DateTimeString:{date.ToDateTimeString()}");
            Debug.WriteLine($"YearMonthString:{date.ToYearMonthString()}");
            Debug.WriteLine($"ToString:{date.ToString(CultureInfo.InvariantCulture)}");
            Debug.WriteLine($"ToShortDateString:{date.ToShortDateString()}");
            Debug.WriteLine($"ToShortTimeString:{date.ToShortTimeString()}");
            Assert.IsTrue(true);
        }
    }
}
