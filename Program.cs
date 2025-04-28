using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Sockets;


namespace Phoenix
{
    class Program
    {
        public static async Task Main()
        {
            String filePath = "banner.txt";

            try
            {
                String content = File.ReadAllText(filePath);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(content);
                Console.ResetColor();
            }
            catch(Exception ex)
            {
                Console.Clear();
            }

            Console.Title = "Phoenix";

            Console.WriteLine("\nEnter Username: ");
            String answer = Console.ReadLine();
            await Phoenix.Username.MainUser(answer);
        }
    }
}
