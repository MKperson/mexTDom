using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominoClassLiberary;

namespace DominoTest
{
    class PrivateTrainTests
    {
        PrivateTrain ppT;
        PrivateTrain cpT;
        Hand pHand;
        Hand cHand;
        Domino d1212;
        Domino d125;
        Domino d512;
        Domino d55;
        BoneYard by;

        [SetUp]
        public void SetUp()
        {
            by = new BoneYard(12);
            pHand = new Hand(by);
            cHand = new Hand(by);
            d1212 = new Domino(12, 12);
            d125 = new Domino(12, 5);
            d512 = new Domino(5, 12);
            d55 = new Domino(5, 5);
            ppT = new PrivateTrain(pHand, 12);
            cpT = new PrivateTrain(cHand, 12);
        }
        [Test]
        public void TestIsPlayable()
        {
            bool mustFlip;
            Assert.IsFalse(cpT.IsPlayable(pHand, d1212, out mustFlip));
            Assert.IsTrue(cpT.IsPlayable(cHand, d1212, out mustFlip));

        }
        [Test]
        public void TestOpenandClose()
        {
            ppT.Close();
            Assert.IsFalse(ppT.IsOpen);
            ppT.Open();
            Assert.IsTrue(ppT.IsOpen);
        }
        [Test]
        public void TestIsOpen()
        {
            Assert.IsFalse(ppT.IsOpen);
            ppT.Open();
            Assert.IsTrue(ppT.IsOpen);
        }
        [Test]
        public void TestEngVal()
        {
            Assert.AreEqual(12, ppT.EngineValue);
        }
        [Test]
        public void TestPlay()
        {
            Assert.IsTrue(ppT.IsEmpty);
            ppT.Play(d1212);
            Assert.IsFalse(ppT.IsEmpty);
            Assert.AreEqual(1, ppT.Count);

        }
        
    }
}
