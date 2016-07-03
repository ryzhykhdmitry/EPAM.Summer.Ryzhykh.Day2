using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AwesomeUI
{
    class AwesomeUI
    {
        static void Main(string[] args)
        {
            //"Testing" Newton's method
            Double newtonResult = NewtonMethod.NewtonMethod.Radical(16, 3, 0);
            Console.WriteLine("3th root of 16 with accuracy 0 is {0} \n", newtonResult);
            Console.WriteLine("Previous result, raised to 3 is {0} \n", Math.Pow(newtonResult, 3));

            Double newtonResult2 = NewtonMethod.NewtonMethod.Radical(16, 3, 0.0001);
            Console.WriteLine("3th root of 16 with accuracy 0.001 is {0} \n", newtonResult2);
            Console.WriteLine("Previous result, raised to 3 is {0} \n", Math.Pow(newtonResult2, 3));
            Console.WriteLine(new String('-', 50));
           
        }
    }
}
