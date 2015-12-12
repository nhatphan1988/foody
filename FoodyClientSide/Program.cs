using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyClientSide
{
    class Program
    {
          static void Main(string[] args)
        {
            // Wait for the async stuff to run...
            Run().Wait();
 
            // Then Write Done...
            Console.WriteLine("");
            Console.WriteLine("Done! Press the Enter key to Exit...");
            Console.ReadLine();
            return;
        }


          static async Task Run()
          {
              // Create an http client provider:
              string hostUriString = "http://localhost:42217";
              var provider = new apiClientProvider(hostUriString);
              string _accessToken;
              Dictionary<string, string> _tokenDictionary;

              try
              {
                  // Pass in the credentials and retrieve a token dictionary:
                  _tokenDictionary = await provider.GetTokenDictionary(
                          "john@example.com", "password");
                  _accessToken = _tokenDictionary["access_token"];
              }
              catch (AggregateException ex)
              {
                  // If it's an aggregate exception, an async error occurred:
                  Console.WriteLine(ex.InnerExceptions[0].Message);
                  Console.WriteLine("Press the Enter key to Exit...");
                  Console.ReadLine();
                  return;
              }
              catch (Exception ex)
              {
                  // Something else happened:
                  Console.WriteLine(ex.Message);
                  Console.WriteLine("Press the Enter key to Exit...");
                  Console.ReadLine();
                  return;
              }

              // Write the contents of the dictionary:
              foreach (var kvp in _tokenDictionary)
              {
                  Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
                  Console.WriteLine("");
              }
          }
    }
}
