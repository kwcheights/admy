using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using ZetaIpc.Runtime.Client;

namespace client
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.SetWindowSize(60, 10);
      var c = new IpcClient();
      c.Initialize(12345);

      Console.WriteLine("Started client");

      try
      {
        var rep = c.Send(args[0]);
        Console.WriteLine("Received: " + rep);
      }
      catch (Exception e)
      {
        Console.WriteLine("Error: did you start the server with admin privileges?");
        Console.WriteLine("Press any key to continue..");
        Console.ReadKey();
      }
    }
  }
}
