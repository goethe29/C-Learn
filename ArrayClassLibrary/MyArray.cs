using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayClassLibrary
{
    public class MyArray
    {
        int[] a;
        int length;
        int Sum;
        //int maxCount;

        /// <summary>
        /// Generate array where n = size of array, first = 2st number, step = step for number incrementation 
        /// </summary>
        /// <param name="n">  size of array</param>
        /// <param name="min">min range</param>
        /// <param name="max">max range</param>
        public MyArray(int n, int first, int step)
        {
            a = new int[n];
            int next = first;

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = next;
                next += step;
                Sum += a[i];
            }
            this.length = a.Length;
            //maxCount = 1;
            // Always = 1. BECAUSE WE HAVE ASCENDING ARRAY! EVERY NEXT NUMBER IS GREATER THAN PREVIOUS ONE. 
            // PLEASE KILL AUTHOR OF METODICHKA/Manual!

        }

        /// <summary>
        /// Method to get/set values of array
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int this[int i]
        {
            get { return a[i]; }
            set { a[i] = value; }
        }

        /// <summary>
        /// Print array (class) as string
        /// </summary>
        public override string ToString()
        {
            string array = "";

            for (int i = 0; i < a.Length; i++)
            {
                array += a[i] + " ";
            }
            return array;
        }

        /// <summary>
        /// Return new array with all numbers from initial array with inversed sign
        /// </summary>
        /// <returns></returns>
        public MyArray Inverse()
        {
            MyArray b = new MyArray(this.length, 0, 0);

            for (int i = 0; i < this.length; i++)
            {
                b[i] = a[i] * -1;
            }

            return b;
        }

        /// <summary>
        /// Mulitiply every member of array by n
        /// </summary>
        /// <param name="n"></param>
        public void Multi(int n)
        {
            for (int i = 0; i < this.length; i++)
            {
                a[i] *= n;
            }
        }
    }
}
