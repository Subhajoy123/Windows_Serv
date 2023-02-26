using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServ
{
    
    internal class util
    {
        public static string path;
        
        public void readConfigFile(string fname, string label)
        {
            string[] strReadFile = System.IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "\\" + fname);
           
                for (int i = 0; i < strReadFile.Length; i++)
                {
                    string[] temp = strReadFile[i].Split('#');
                    if (temp[0] == label)
                    {
                        path = temp[1].Substring(0, temp[1].Length - 1);

                        break;
                    }



                }
           
            
            
        }

    }
}
