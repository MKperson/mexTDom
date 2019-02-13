using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClassLiberary
{
    public class PrivateTrain : MainTrain
    {
        //Hand hand;
        bool isOpen;

        bool IsOpen
        {
            get
            {
                return isOpen;
            }
        }

        public PrivateTrain(Hand h, int engValue):base(engValue)
        {

        }
        public void Open()
        {
            isOpen = true;
        }
        public void Close()
        {
            isOpen = false;
        }
        
    }
}
