﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skender.Stock.Indicators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Internal.Tests
{
    [TestClass]
    public class HeikinAshiTests : TestBase
    {

        [TestMethod()]
        public void GetHeikinAshiTest()
        {

            IEnumerable<HeikinAshiResult> results = Indicator.GetHeikinAshi(history);

            // assertions

            // should always be the same number of results as there is history
            Assert.AreEqual(502, results.Count());

            // sample value
            HeikinAshiResult r = results.Where(x => x.Index == 502).FirstOrDefault();
            Assert.AreEqual(241.3018m, Math.Round(r.Open, 4));
            Assert.AreEqual(245.54m, Math.Round(r.High, 4));
            Assert.AreEqual(241.3018m, Math.Round(r.Low, 4));
            Assert.AreEqual(244.6525m, Math.Round(r.Close, 4));
        }


        /* EXCEPTIONS */

        [TestMethod()]
        [ExpectedException(typeof(BadHistoryException), "Insufficient history.")]
        public void InsufficientHistory()
        {
            Indicator.GetHeikinAshi(history.Where(x => x.Index < 2));
        }

    }
}