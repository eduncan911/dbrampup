using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

using System.Reflection;
using CmdParser;

namespace DBRampUp
{
    

    class Program
    {
        static void Main(string[] args)
        {
            SetupArgs setupArgs = new SetupArgs();
            DBRampUpProvider setup = null;
            try
            {
                Parameters parms = Parameters.CreateParameters(setupArgs, args);

                if (parms.IsHelpNeeded)
                {
                    string helpString = "";
                    switch (parms.HelpChars)
                    {
                        case "?":
                            helpString = parms.GetUsageString(Assembly.GetExecutingAssembly(), 10);
                            Console.WriteLine("\nUsage:");
                            Console.WriteLine(helpString);
                            Console.WriteLine("Note: For detailed help, use -??, -h, or -help.");
                            break;
                        case "h":
                        case "help":
                        case "??":
                            helpString = parms.GetDetailedHelp(Assembly.GetExecutingAssembly());
                            Console.WriteLine();
                            Console.WriteLine(helpString);
                            break;
                    }
                    return;
                }
                if (parms.BeenSetCount == 0)
                {
                    // No parameters set at commandline, so display help.
                    // This could mean something else to your program.
                    string helpString = parms.GetUsageString(Assembly.GetExecutingAssembly(), 10);
                    Console.WriteLine("\nUsage:");
                    Console.WriteLine(helpString);
                    Console.WriteLine("Note: For detailed help, use -??, -h, or -help.");
                    Console.ReadLine();
                    return;
                }

                if (setupArgs.Debug)
                {
                    Console.WriteLine("Press enter after you've attached");
                    Console.ReadLine();
                }
                setup = DBRampUpProvider.Instance();
                System.Environment.ExitCode = setup.Execute(setupArgs);
                
            }
            catch (Exception ex)
            {
				System.Environment.ExitCode = 1;
                Console.WriteLine(ex.ToString());
            }
            
        }

    }
}
