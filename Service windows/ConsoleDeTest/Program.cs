using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Threading;

namespace ConsoleDeTest
{
    class Program
    {



        static PerformanceCounter processor;
        static PerformanceCounter ram;

        static void Main(string[] args)
        {
            //  func0();
            //  Console.ReadLine();

           
            processor = new PerformanceCounter("Processor", @"% Processor Time", @"_Total");
            ram = new PerformanceCounter("Memory","Available Mbytes");


            float tailleRam = ram.NextValue();

            
            while (true)
            {
                Console.WriteLine(@"Current value of Processor,Total= " + processor.NextValue().ToString());
                Console.WriteLine(tailleRam + "MB");      
                Thread.Sleep(1000);
            }

        }
    }
}
