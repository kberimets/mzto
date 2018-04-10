using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mzto.DAL;
using Common;
using Shouldly;
using MztoUploader;

namespace TestMzto
{
    [TestClass]
    public class TestMztoDAL
    {
        private string _connectionString = "data source=gmsql-sver;initial catalog=mzto;integrated security=True;MultipleActiveResultSets=True;";

        [TestMethod]
        public void TestGetDomains()
        {
            var dac = new MztoDac(_connectionString);

            var domains = dac.GetDomains();

            domains.Length.ShouldBe(5);
            domains[0].Name.ShouldBe("Наблюдаемые. Свердловская энергосистема.");

            var powerCenters = domains[0].PowerCenters;
            powerCenters.Length.ShouldBe(3);
            powerCenters[0].Name.ShouldBe("ПС 110 кВ Авиатор");
            powerCenters[0].IsObservable.ShouldBe(true);

            var parameters = powerCenters[0].Parameters;
            parameters.Length.ShouldBe(13);

            parameters[0].Description.ShouldBe("ТИ-источник");
            parameters[0].MztoType.ShouldBe(MztoType.SourceTi);
        }
    }
}
