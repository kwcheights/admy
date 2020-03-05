using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using ZetaIpc.Runtime.Server;

namespace server
{
  class Program
  {
    private static Mutex mutex = null;

    static void Main()
    {
      Console.SetWindowSize(60, 10);
      //Settings for single instance app start
      const string appName = "admy_server";
      bool createdNew;
      mutex = new Mutex(true, appName, out createdNew);
      if (!createdNew)
      {
        //app is already running! Exiting the application  
        return;
      }
      //Settings for single instance app end

      var s = new IpcServer();
      s.Start(12345); // Passing no port selects a free port automatically.

      Console.WriteLine("Started server on port {0}, input \"quit\" to exit", s.Port);

      s.ReceivedRequest += (sender, args) =>
      {
        args.Response = args.Request;
        Console.WriteLine("I've got: " + args.Response);
        try
        {
          Process.Start(args.Response);
        }
        catch (Exception e)
        {
          Console.WriteLine(e.Message);
        }
        args.Handled = true;
      };

      bool stay = true;
      string command;
      while (stay)
      {
        command = Console.ReadLine();
        if (command == "quit") stay = false;
      }
      s.Stop();
    }

    //private void start_process(string file)
    //{
    //  Console.WriteLine(file);

    //}
  }
}
