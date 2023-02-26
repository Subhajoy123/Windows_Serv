using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using WindowsServ;

namespace Quiz
{
    
    public partial class Service1 : ServiceBase
    {
        public static int name;
        public Service1()
        {
            InitializeComponent();
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            
            System.Timers.Timer timer = new System.Timers.Timer();
            util c = new util();
            c.readConfigFile("Configure.sys", "Interval");
            timer.Interval = Convert.ToDouble(util.path);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();
            
            

        }
        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            try
            {
                string[] g = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory  + "ServiceLog").Select(Path.GetFileName).ToArray();
                if (g.Length == 0)
                {
                    name = 0;
                }
                util c = new util();
                c.readConfigFile("Configure.sys", "Target_Dir");
                string targetPath = util.path;
                c.readConfigFile("Configure.sys", "Source_Dir");
                string sourcePath = util.path;
                c.readConfigFile("Configure.sys", "Interval");
                string interval = util.path;






                FileStream TS = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\" + "ServiceLog" + "\\"+ "Log" + name.ToString() + "_" + "record.txt", FileMode.Append);
                string lines = "Service: Started Successfully: " + DateTime.Now.ToString();
              
                long length = new System.IO.FileInfo(AppDomain.CurrentDomain.BaseDirectory + "\\" + "ServiceLog" + "\\" + "Log" + name.ToString() + "_" + "record.txt").Length;
                System.IO.StreamWriter file = new System.IO.StreamWriter(TS);
                
                    
                file.WriteLine("\n" + lines + "\n" + Environment.OSVersion + " " + Environment.UserName + " " + Environment.SystemDirectory + "\n" + "Source Dir :" + sourcePath + "; " + "Target Dir :" + targetPath + "; " + "Interval :" + interval + ";\n ");
                file.Close();
                TS.Close();


                if (length > 100000)
                {
                    
                    name++;

                }
                    




                string[] f = Directory.GetFiles(targetPath).Select(Path.GetFileName).ToArray();

                int l = f.Length;
                    if (l == 0)
                    {
                        string m = String.Empty;
                        var q = Directory.GetFiles(sourcePath).Select(name => new FileInfo(name));

                        var o = q.OrderBy(FileInfo => FileInfo.CreationTime).ToList();
                        foreach (var i in o)
                        {
                            m = i.Name;
                            break;
                        }
                        //Console.WriteLine(m);

                        string s = sourcePath;


                        System.IO.File.Copy(s + "\\" + m, targetPath + "\\" + "OnStart.csv", true);
                        System.IO.File.Delete(s + "\\" + m);
                    }
                
                
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\" + "ServiceLog" + "\\" + "Log" + name.ToString() + "_" + "record.txt", ex.Message +"\n");
                
                
             
            }

            
            
        }
      

        protected override void OnStop()
        {
            
                /*util c = new util();
                c.readConfigFile("Configure.sys", "Target_Dir");
                string targetPath = util.path;*/
                
               
                System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\" + "ServiceLog" + "\\" + "Log" + name.ToString() + "_" + "record.txt", "Service: Stopped Successfully: " + DateTime.Now.ToString() + "\n");
        }
           
           

        }
     

    }

