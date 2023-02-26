using System;
using ConfigureEdit;

namespace FileEdit
{
    class Program
    {
        public static void Main(string[] args)
        {
            util c = new util();
            //c.readConfigAll("Configure.sys");
            c.readConfigSpecific("Configure.sys", "Interval");
            
            string[] g = System.IO.Directory.GetFiles(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\..\"))+ "ServiceLog").Select(Path.GetFileName).ToArray();
            Console.WriteLine(g.Length);
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}