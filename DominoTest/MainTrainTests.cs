using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominoClassLiberary;


namespace DominoTest
{
    [TestFixture]
    class MainTrainTests
    {
        MainTrain MexT;
        Domino d1212;
        Domino d512;
        Domino d125;


        //finish this!!!
        [SetUp]
        public void SetUp()
        {
            MexT = new MainTrain(12);
            d1212 = new Domino(12, 12);
            d512 = new Domino(5, 12);
            d125 = new Domino(12, 5);
        }
        [Test]
        public void Play()
        {
            
            MexT.Play(d125);
            Assert.AreEqual(1, MexT.Count);
            Assert.AreEqual(5, MexT.PlayableValue);
        }

    }
}
