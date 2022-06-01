using GRM_App.InputFileParsers;
using NUnit.Framework;
using System;

namespace GRM_App_UnitTests
{
    public class DistributionPartnerContractFileParserTests
    {
        [Test]
        public void ValidFileTest()
        {
            var contractParser = new DistributionPartnerContractFileParser();
            var contracts = contractParser.GetContracts(@"TestInputFiles\Distribution_Partner_Contracts_Valid.txt");

            Assert.AreEqual(contracts.Count, 2);
            Assert.AreEqual(contracts[0].Partner, "ITunes");
            //TODO: other asserts
        }

        [Test]
        public void InvalidFileHeaderTest()
        {
            var contractParser = new DistributionPartnerContractFileParser();
            Assert.Throws<FormatException>(() => contractParser.GetContracts(@"TestInputFiles\Distribution_Partner_Contracts_InvalidHeader.txt"));
        }
        
        //TODO: tests on input files with other errors. e.g.: lines skipped due to bad format
    }
}