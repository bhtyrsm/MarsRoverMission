using System;
using MarsRoverMission;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverMissionTest
{
    [TestClass]
    public class MissionTest
    {
        [TestMethod]
        public void TestMethod_1_2_N_LMLMLMLMM()
        {
            Rover rover = new Rover();
            rover.setBoundaries("5 5");
            rover.ValidateAndSetStartPosition("1 2 N");
            rover.Move("LMLMLMLMM");

            var espectedResult = "1 3 N";
            var roverResult = rover.Position_X.ToString()+ " " + rover.Position_Y.ToString()+ " " + rover.Direction.ToString();

            Assert.AreEqual(espectedResult, roverResult);
        }

        [TestMethod]
        public void TestMethod_3_3_E_MMRMMRMRRM()
        {
            Rover rover = new Rover();
            rover.setBoundaries("5 5");
            rover.ValidateAndSetStartPosition("3 3 E");
            rover.Move("MMRMMRMRRM");

            var espectedResult = "5 1 E";
            var roverResult = rover.Position_X.ToString() + " " + rover.Position_Y.ToString() + " " + rover.Direction.ToString();

            Assert.AreEqual(espectedResult, roverResult);
        }
    }
}
