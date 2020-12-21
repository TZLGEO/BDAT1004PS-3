using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DATAssignment
{
    public static class GetTotalX
    {    

        public static int GetTotalx(int[] arrayA, int[] arrayB)
        {
            //returning value from the function.
            int count = 0;
            //gets the last element in the first array
            int currentElement = arrayA[arrayA.Length - 1];
            int flag;

            //as long as the current element is less or equal to the first element in B continue the loop
            while (currentElement <= arrayB[0])
            {
                flag = 0;
                //if not a factor break out of the loop
                for (int i = 0; i < arrayA.Length; i++)
                {
                    if(currentElement % arrayA[i] != 0)
                    {
                        flag = 1;
                        break;
                    }

                }

                if(flag == 0)
                {
                    for (int i = 0; i < arrayB.Length; i++)
                    {
                        if (arrayB[i] % currentElement != 0)
                        {
                            flag = 1;
                            break;
                        }

                    }

                }

                if (flag == 0) count++;

                currentElement++;

            }

            return count;
        }
    }
}
