using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConfigureEdit
{
    internal class util
    {
        public void readConfigAll(string fname)
        {
            try
            {
                string pathConfig = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\..\")) + fname;
                string[] strReadFile = System.IO.File.ReadAllLines(pathConfig);
                foreach (string str in strReadFile)
                {
                    Console.WriteLine(str);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
        }
        public void readConfigSpecific(string fname, string label)
        {
            try
            {
                string pathConfig = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\..\")) + fname;
                string[] strReadFile = System.IO.File.ReadAllLines(pathConfig);
                int k = 0;
                for(int i = 0; i < strReadFile.Length; i++)
                {
                    string[] temp = strReadFile[i].Split('#');
                    if (temp[0] == label)
                    {
                        Console.WriteLine(label+" :" + temp[1].Substring(0,temp[1].Length-1));
                        k = 1;
                        break;
                    }
                }
                if(k == 0)
                {
                    Console.WriteLine("label not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void writeConfig(string fname, string label, string value)
        {
            try
            {
                string pathConfig = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\..\")) + fname;
                string[] strReadFile = System.IO.File.ReadAllLines(pathConfig);
                int k = 0;
                for (int i = 0; i < strReadFile.Length; i++)
                {
                    int j = strReadFile[i].IndexOf('#');
                    int e = strReadFile[i].IndexOf(";");
                    string[] temp = strReadFile[i].Split('#');
                    if (temp[0] == label)
                    {
                        string sub = strReadFile[i].Substring(j+1,e-j);
                        strReadFile[i] = strReadFile[i].Replace(sub,value+';');
                        System.IO.File.WriteAllLines(pathConfig,strReadFile);
                        k = 1;
                        break;
                    }
                }
                if (k == 0)
                {
                    Console.WriteLine("label not found");
                }
                else
                {
                    Console.WriteLine(fname + " is modified");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

