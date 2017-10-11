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
    class BoneYardTests
    {
        private BoneYard byone;
        private BoneYard by;
        private Domino d1212;
        private Domino d00;

        [SetUp]
        public void Setup()
        {
            byone = new BoneYard(0);
            by = new BoneYard(12);
            d1212 = new Domino(12, 12);
            d00 = new Domino(0, 0);

        }


        [Test]
        public void TestConstuctor()
        {
            Assert.AreEqual(91, by.DominosRemaining);
            Assert.AreEqual(d1212, by[0]);
            Assert.AreEqual(d00, by[by.DominosRemaining - 1]);
        }

        [Test]
        public void TestIsEmpty()
        {
            Assert.IsFalse(byone.IsEmpty());
            byone.Draw();
            Assert.IsTrue(byone.IsEmpty());
        }
        [Test]
        public void TestDominoRemaining()
        {
            Assert.AreEqual(91, by.DominosRemaining);
            by.Draw();
            Assert.AreEqual(90, by.DominosRemaining);
            
        }


        [Test]
        public void TestShuffle()
        {
            Console.WriteLine(by);
            by.Shuffle();
            Console.WriteLine(by);
        }
        [Test]
        public void TestToString()
        {
            Console.WriteLine(by.ToString());
        }

    }
}
