using System;
using System.Linq;
using System.Net;
using System.Threading;

namespace ConsoleGetRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args != null && args.Any())
            {
                var timer = new Timer(Get, args[0], 1000, 5*60*1000);


            }
            Console.ReadLine();
            
        }

        private static void Get(object state)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create((string)state);

                using (var httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    Console.WriteLine(DateTime.Now + " " + httpWebReponse.StatusDescription);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + " " + ex.Message);
            }
            
        }
    }
}
