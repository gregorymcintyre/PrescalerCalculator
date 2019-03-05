/*Prescale Calculator
 * Greg McIntyre
 * 5/3/19
 * 
 * Shitty program for calculting prescale values for microprocessors
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrescalerCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            float processorSpeed;
            float timeInterval;
            float value;
            int[] scale = { 1, 8, 64, 256, 1024 };
            float[] outputs = new float[5];

            Console.WriteLine("Prescaler Calculator 0.1\nGreg Mcintyre\t5/3/2019\n");
            
            Console.WriteLine("Please enter the processor speed in whole megaherts (MHz)");
            while (!(float.TryParse(Console.ReadLine(), out processorSpeed)))
            {
                Console.WriteLine("Please enter a valid value");
            };

            Console.WriteLine("Please enter the time interval in miliseconds (ms)");
            while (!(float.TryParse(Console.ReadLine(), out timeInterval)))
            {
                Console.WriteLine("Please enter a valid value");
            };

            Console.WriteLine(
                "\n     Prescaler\tCount\tRegister Size\n" +
                  "     --------------------------------");

            for (int i = 0; i < 5; i++)
            {
                value = PrescaleConvert(processorSpeed, scale[i], timeInterval);
                outputs[i] = value;
                Console.WriteLine(
                    "\t" + scale[i] + "\t" + value + "\t\t" + eightorsixteen(value));
            }
            
            
            for(int i=4 ; i > 0 ; i--) 
            {
                if (outputs[i] % 1==0)
                {
                    Console.WriteLine("\nthe most ideal value is " + outputs[i] + " in a " + eightorsixteen(outputs[i]) + " bit register, with a prescaler of " + scale[i]);
                    break;
                }
            }
            
            Console.WriteLine();


            float PrescaleConvert(float processor, float scalevalue, float time)
            {
                float output;
                output = (time / 1000) * (processor * 1000000) / scalevalue;
                return output;
            }

            int eightorsixteen(float input)
            {
                if (input < 255)
                {
                    return 8;
                }
                else if (input < 65353)
                {
                    return 16;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
