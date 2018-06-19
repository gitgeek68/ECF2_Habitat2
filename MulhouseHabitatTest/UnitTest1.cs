using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MulhouseHabitat.Models;

namespace MulhouseHabitatTest
{
    [TestClass]
    public class UnitTest1
    {

        Dal dal = new Dal();


        [TestMethod]
        public void TestMethod1()
        {
            MHLogements logements = new MHLogements();

            logements.Type = "appartement";
            logements.StreetNumber = "9";
            logements.StreetName = "Jean des Fontaine";
            logements.PostalCode = "31400";
            logements.City = "Toulouse";
            logements.NumberOfPieces = 5;
            logements.Size = 75;
            logements.Rented = false;


            int nbLogements = dal.GetLogements().Count;

            dal.AddLogement(logements);

            Assert.AreEqual((nbLogements + 1), dal.GetLogements().Count);
        }
    }
}
