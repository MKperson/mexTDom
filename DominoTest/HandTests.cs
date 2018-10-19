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
    class HandTests
    {
        Hand hand;



        [SetUp]
        public void SetUp()
        {
            BoneYard yard = new BoneYard(12);
            yard.Shuffle();
            hand = new Hand(yard);

        }

        [Test]
        public void HasDominos()
        {
            Assert.AreEqual(7, hand.Dominos.Count());
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(hand.Dominos[i]);
            }
        }




    }
}
