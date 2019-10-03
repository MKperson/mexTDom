using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClassLiberary
{
    public class MainTrain
    {
        protected List<Domino> dominos;

        int engineValue;


        public int Count
        {
            get
            {
                return dominos.Count;
            }
        }
        public int EngineValue
        {
            get
            {
                return engineValue;
            }
            set
            {
                engineValue = value;
            }
        }
        public bool IsEmpty
        {
            get
            {
                if (Count == 0)
                    return true;
                else
                    return false;
            }
        }
        public Domino LastDomino
        {
            get
            {
                if (Count == 0)
                    return null;
                else
                return dominos[dominos.Count - 1];
            }
        }
        public int PlayableValue
        {
            get
            {
                if (Count == 0)
                    return engineValue;
                else
                    return LastDomino.Side2;
            }
        }
        public Domino this[int index]
        {
            get
            {
                return dominos[index];
            }

        }

        public bool IsPlayable(Domino d ,out bool mustFlip)
        {
            
            if (d.Side1 == PlayableValue)
            {
                mustFlip = false;
                return true;
            }
            else if (d.Side2 == PlayableValue)
            {
                mustFlip = true;
                return true;
            }
            else
            {
                mustFlip = false;
                return false;
            }
           
        }
        public void Play(Domino d)
        {
            bool mustFlip;
            if(IsPlayable(d, out mustFlip))
            {
                if (mustFlip == false)
                {
                    dominos.Add(d);
                    
                }
                else
                {
                    d.Flip();
                    dominos.Add(d);
                   
                }
            }
            else
            {
                throw new Exception("Can not Play domino");
            }

        }

        public MainTrain(int engValue)
        {
            dominos = new List<Domino>();
            engineValue = engValue;
        }

        public override string ToString()
        {
            string s = "";
            foreach (Domino d in dominos)
            {
                s += d.ToString();
            }
            return s;
        }


    }
}
