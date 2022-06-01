using GRM_App.Utils;
using NUnit.Framework;
using System;

namespace GRM_App_UnitTests
{
    public class DateTimeUtilsTests
    {
        [Test]
        public void ValidDateTest()
        {
            var date = DateTimeUtils.ParseDateString("1st May 2012");
            Assert.AreEqual(date.Year, 2012);
            Assert.AreEqual(date.Month, 5);
            Assert.AreEqual(date.Day, 1);

            date = DateTimeUtils.ParseDateString("11th May 2012");
            Assert.AreEqual(date.Year, 2012);
            Assert.AreEqual(date.Month, 5);
            Assert.AreEqual(date.Day, 11);

            date = DateTimeUtils.ParseDateString("11th December 2012");
            Assert.AreEqual(date.Year, 2012);
            Assert.AreEqual(date.Month, 12);
            Assert.AreEqual(date.Day, 11);
        }

        [Test]
        public void InvalidDateTest()
        {
            Assert.Throws<FormatException>(() => DateTimeUtils.ParseDateString("30th Feb 2012"));

            Assert.Throws<IndexOutOfRangeException>(() => DateTimeUtils.ParseDateString("11thFeb2012"));

            Assert.Throws<IndexOutOfRangeException>(() => DateTimeUtils.ParseDateString("11th Feb2012"));

            Assert.Throws<IndexOutOfRangeException>(() => DateTimeUtils.ParseDateString("11thFeb 2012"));
        }
    }
}