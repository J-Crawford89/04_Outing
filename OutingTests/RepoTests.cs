using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutingChallenge;

namespace OutingTests
{
    [TestClass]
    public class RepoTests
    {
        OutingRepository _outingRepo = new OutingRepository();
        Outing outingOne = new Outing(Outing.OutingType.AmusementPark, 12, new DateTime(2019, 07, 20), 33.72);
        Outing outingTwo = new Outing(Outing.OutingType.Concert, 23, new DateTime(2019, 11, 16), 21.12);
        [TestMethod]
        public void GetAllOutings_ShouldListOutings()
        {
            _outingRepo.AddToDirectory(outingOne);
            _outingRepo.AddToDirectory(outingTwo);

            _outingRepo.ShowAllOutings();
        }
        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBool()
        {
            bool wasAdded = _outingRepo.AddToDirectory(outingOne);

            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void GetTotalCost_ShouldGetTotalCost()
        {
            _outingRepo.AddToDirectory(outingOne);
            _outingRepo.AddToDirectory(outingTwo);

            double actual = _outingRepo.GetTotalCost();
            double expected = outingOne.TotalCost + outingTwo.TotalCost;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetCostByType_ShouldGetCorrectCost()
        {
            _outingRepo.AddToDirectory(outingOne);
            _outingRepo.AddToDirectory(outingTwo);

            double actual = _outingRepo.GetTotalCostByType(Outing.OutingType.Concert);
            double expected = outingTwo.TotalCost;

            Assert.AreEqual(expected, actual);

        }
    }
}
