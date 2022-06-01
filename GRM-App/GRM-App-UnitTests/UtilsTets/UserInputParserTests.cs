using GRM_App.Utils;
using NUnit.Framework;
using System;

namespace GRM_App_UnitTests
{
    public class UserInputParserTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidInputTest()
        {
            string partnerName;
            DateTime effectiveDate;

            UserInputUtils.ParseUserInput("ITunes 1st March 2012", out partnerName, out effectiveDate);

            Assert.AreEqual(partnerName, "ITunes");
            Assert.AreEqual(effectiveDate.Year, 2012);
            Assert.AreEqual(effectiveDate.Month, 3);
            Assert.AreEqual(effectiveDate.Day, 1);
        }

        [Test]
        public void EmptyInputTest()
        {
            string partnerName;
            DateTime effectiveDate;

            Assert.Throws<ArgumentOutOfRangeException>(() => UserInputUtils.ParseUserInput("", out partnerName, out effectiveDate));
        }

        [Test]
        public void InvalidDateInputTest()
        {
            string partnerName;
            DateTime effectiveDate;

            Assert.Throws<FormatException>(() => UserInputUtils.ParseUserInput("ITunes 1st Month 2012", out partnerName, out effectiveDate));
            Assert.Throws<IndexOutOfRangeException>(() => UserInputUtils.ParseUserInput("ITunes 1st May-2012", out partnerName, out effectiveDate));
            Assert.Throws<IndexOutOfRangeException>(() => UserInputUtils.ParseUserInput("ITunes 1stMonth2012", out partnerName, out effectiveDate));
        }

        [Test]
        public void InvalidInputSpacingTest()
        {
            string partnerName;
            DateTime effectiveDate;

            Assert.Throws<IndexOutOfRangeException>(() => UserInputUtils.ParseUserInput("ITunes1st Month 2012", out partnerName, out effectiveDate));
        }
    }
}