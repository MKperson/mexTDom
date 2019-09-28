using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClassLiberary
{
    public class PrivateTrain : MainTrain
    {
        Hand hand;
        bool isOpen = false;

        public bool IsOpen
        {
            get
            {
                return isOpen;
            }
        }

        public PrivateTrain(Hand h, int engValue) : base(engValue)
        {
            hand = h;
        }
        public void Open()
        {
            isOpen = true;
        }
        public void Close()
        {
            isOpen = false;
        }
       
        public bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {

            if (h == hand)
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
            else if(IsOpen)
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
            else
            {
                mustFlip = false;
                return false;
            }
        }
    }
}
