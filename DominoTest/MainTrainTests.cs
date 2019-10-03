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
        Domino d55;


        //finish this!!!
        [SetUp]
        public void SetUp()
        {
            MexT = new MainTrain(12);
            d1212 = new Domino(12, 12);
            d512 = new Domino(5, 12);
            d125 = new Domino(12, 5);
            d55 = new Domino(5, 5);
        }
        [Test]
        public void Play()
        {
            
            MexT.Play(d125);
            Assert.AreEqual(1, MexT.Count);
            Assert.AreEqual(5, MexT.PlayableValue);
        }
        [Test]
        public void Isplayable()
        {
            bool mustFlip;
            Assert.IsTrue(MexT.IsPlayable(d512, out mustFlip));
            Assert.IsTrue(mustFlip);
            Assert.IsFalse(MexT.IsPlayable(d55, out mustFlip));
           
        }
        [Test]
        public void EngineVal()
        {
            Assert.AreEqual(12, MexT.EngineValue);
        }
        [Test]
        public void Isempty()
        {
            Assert.IsTrue(MexT.IsEmpty);
            MexT.Play(d125);
            Assert.IsFalse(MexT.IsEmpty);
        }
        [Test]
        public void Lastdomino()
        {
            Assert.IsNull(MexT.LastDomino);
            MexT.Play(d125);
            Assert.AreEqual(d125, MexT.LastDomino);
        }
        [Test]
        public void TestToString()
        {
            Console.WriteLine(MexT.ToString());
            MexT.Play(d125);
            Console.WriteLine(MexT.ToString());
        }

    }
}
