using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DominoClassLiberary
{
    public class Hand
    {
        private List<Domino> listOfDominos;

        public List<Domino> Dominos
        {
            get
            {
                return listOfDominos;
            }
         
        }

        public Hand(BoneYard yard)
        {
            listOfDominos = new List<Domino>();
            for(int i = 0; i < 7; i++)
            {
                listOfDominos.Add(yard.Draw());
                
            }
        }
    }
}
