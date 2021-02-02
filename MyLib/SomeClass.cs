using System;

namespace MyLib
{
    public class SomeClass
    {
        /// <summary>
        /// return a multiplication of x and the number within n 
        /// </summary>
        /// <param name="x">The value to be multiplied</param>
        /// <param name="n">The value of the figure to be multiplied must be '2' or '3'</param>
        /// <exception cref="System.ArgumentNullException">Thrown when n is null or empty</exception>
        /// <exception cref="System.ArgumentException">Thrown when n is not '2' or '3'</exception>
        /// <returns>The value x multiplied by two or three depending on the value in n</returns>
        public int SomeMethod(int x, String n)
        {
            if (string.IsNullOrWhiteSpace(n)) throw new ArgumentNullException("n must have a value but was null or empty");
            if (! (n=="2" || n=="3")) throw new ArgumentException("Only '2' or '3' is supported but was " + n);

            switch (n)
            {
                case "2" : return x * 2;
                case "3" : return x * 3;
            }
            
            throw new NotImplementedException("");
        }

        
    }
}
