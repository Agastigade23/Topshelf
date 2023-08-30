using Serilog;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Topshelf_Net_6
{
    public class ServiceExample
    {

        /*
        private Timer timer;
        private int count;

        public ServiceExample()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("C:\\LogFiles\\Topshelf_Net_6\\log.txt")
                .CreateLogger();

            this.timer = new Timer() { AutoReset = true, Interval = 30000 };
            this.timer.Elapsed += (s, e) => Log.Information($"Count = {this.count++}");
        }

        public void Start()
        {
            Log.Information("Started");
            this.timer.Start();
        }

        public void Stop()
        {
            Log.Information("Stopped");
            this.timer.Stop();
        }
        */

        System.Timers.Timer timer = new System.Timers.Timer();
        public void Start()
        {
            WriteToFile("Service started. Timestamp " + DateTime.Now);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 6000;
            timer.Enabled = true;
        }
        public void Stop()
        {
            WriteToFile("Service stopped. Timestamp " + DateTime.Now);
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            WriteToFile("Service invoked. Timestamp: " + DateTime.Now);
        }
        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\LocalLog";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\LocalLog\\Log_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }
    }
}
