using GRM_App.InputFileParsers;
using NUnit.Framework;
using System;

namespace GRM_App_UnitTests
{
    public class MusicContractsFileParserTests
    {
        [Test]
        public void ValidFileTest()
        {
            var contractParser = new MusicContractsFileParser();
            var contracts = contractParser.GetContracts(@"TestInputFiles\Music_Contracts_Valid.txt");

            Assert.AreEqual(contracts.Count, 7);
            Assert.AreEqual(contracts[0].Artist, "Tinie Tempah");
            //TODO: other asserts
        }

        [Test]
        public void InvalidFileHeaderTest()
        {
            var contractParser = new MusicContractsFileParser();
            Assert.Throws<FormatException>(() => contractParser.GetContracts(@"TestInputFiles\Music_Contracts_InvalidHeader.txt"));
        }

        //TODO: tests on input files with other errors. e.g.: lines skipped due to bad format
    }
}