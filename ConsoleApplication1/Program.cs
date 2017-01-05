using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.IO.Pipes;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Process cmd = new Process();
            cmd.StartInfo.WorkingDirectory = string.Format(@"{0}", System.Environment.CurrentDirectory);
            cmd.StartInfo.FileName = "gcc";
            cmd.StartInfo.Arguments = " -O2 -c main.c";
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.RedirectStandardError = true;
            cmd.Start();
            cmd.WaitForExit();
            
           // cmd.StandardOutput.ReadToEnd()
            if(cmd.ExitCode != 0)
            {
                Console.WriteLine("error1");
            }
            cmd.StartInfo.Arguments = " -O2 -c foo.c";
            cmd.Start();
            cmd.WaitForExit();
            if (cmd.ExitCode != 0)
            {
                Console.WriteLine("error2");
            }
            cmd.StartInfo.FileName = "gcc";
            cmd.StartInfo.Arguments = " main.o foo.o -o main";
            cmd.Start();
            cmd.WaitForExit();
            if (cmd.ExitCode != 0)
            {
                Console.WriteLine("error3");
            }
            string sout = cmd.StandardOutput.ReadToEnd();
            string serr = cmd.StandardError.ReadToEnd();

            //NamedPipeServerStream pipeServer = new NamedPipeServerStream("aaaa");
           // NamedPipeClientStream pipeClient = new NamedPipeClientStream("aaaa");
            
            Console.WriteLine(sout);
            //Console.WriteLine(sout);
            //Console.WriteLine("std error:");
            //Console.WriteLine(serr);

        }
    }
}
