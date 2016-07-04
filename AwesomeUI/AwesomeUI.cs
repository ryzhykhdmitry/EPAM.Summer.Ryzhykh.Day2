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
            //double newtonresult = newtonmethod.newtonmethod.radical(16, 0, 0);
            //console.writeline("3th root of 16 with accuracy 0 is {0} \n", newtonresult);
            //console.writeline("previous result, raised to 3 is {0} \n", math.pow(newtonresult, 3));

            //double newtonresult2 = newtonmethod.newtonmethod.radical(16, 3, 0.0001);
            //console.writeline("3th root of 16 with accuracy 0.001 is {0} \n", newtonresult2);
            //console.writeline("previous result, raised to 3 is {0} \n", math.pow(newtonresult2, 3));
            //console.writeline(new string('-', 50));
            long myTime = 0;
            Double euResult = MathMethods.MathMethods.EuclidAlgorithm(out myTime, 24, 72, 78, 181);
            Console.WriteLine("{0} \b {1}",euResult, myTime);
        }
    }
}
