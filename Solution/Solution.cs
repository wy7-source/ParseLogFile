using System;

namespace Solution
{
    class Solution
    {
        public int solution(int[] A)
        {
            // Our two-dimensional Array
            int[,] adjacentNumbers = new int[(A.Length*2),2];
            // Next line of our Array
            int line = 0;
            // result of calc for know the higherNumber
            int res = 0;
            // Higher distance of Adjacent numbers
            int higherNumber = -2;
            // Length of your array
            int arrLength = A.Length;

            // Before, we collect the indices.
            for(int i = 0; i < arrLength; i++)
            {
                for(int j = i+1; j < arrLength; j++)
                {
                    int min = A[i];
                    int max = A[j];

                    if(min > max)
                    {
                        int aux = min;
                        min = max;
                        max = aux;
                    }

                    int result = Array.Find(A, element => element > min && element < max);

                    if(result == 0 )
                    {
                        adjacentNumbers[line,0] = i;
                        adjacentNumbers[line,1] = j;
                        line++;
                    }
                }
            }
            
            // Then, calculate the longest distance of adjacent numbers.
            for(int l = 0; l < (A.Length*2); l++)
            {
                int a = A[adjacentNumbers[l,0]];
                int b = A[adjacentNumbers[l,1]];
                res = (a - b)*1;      
                if(res > higherNumber)
                {
                    higherNumber = res;
                } 
            }
            return higherNumber;
        }
    }
}
