using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        DraftManager draftManager = new DraftManager();

        string input;
        while ((input = Console.ReadLine()) != "Shutdown")
        {
            var args = input.Split().ToList();
            var command = args[0];

            args = args.Skip(1).ToList();
            string rslt = null;
            try
            {
                switch (command)
                {
                    case "RegisterHarvester":
                        rslt = draftManager.RegisterHarvester(args);
                        break;

                    case "RegisterProvider":
                        rslt = draftManager.RegisterProvider(args);
                        break;

                    case "Day":
                        rslt = draftManager.Day();
                        break;

                    case "Check":
                        rslt = draftManager.Check(args);
                        break;

                    case "Mode":
                        rslt = draftManager.Mode(args);
                        break;
                    default:
                        throw new ArgumentException("Invalid command");
                }

                Console.WriteLine(rslt);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        Console.WriteLine(draftManager.ShutDown());
    }
}

