using IntroSoapService;
using System;
using System.Net.Http;
using System.Net.Mime;
using System.Text;

namespace Consumer.App
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44314");
            client.GetAsync("/fruits").ContinueWith(r =>
            {
                if (r.IsCompletedSuccessfully)
                {
                    string s = r.Result.Content.ReadAsStringAsync().Result;

                    Console.WriteLine($">> {s}");
                }
            }).Wait();
            StringContent content = new StringContent("", Encoding.UTF8,MediaTypeNames.Application.Json);
            client.PostAsync("/fruits", content)
                .ContinueWith(r =>
                {
                   if (r.IsCompletedSuccessfully)
                    {
                      string s=  r.Result.Content.ReadAsStringAsync().Result;
                        Console.WriteLine($">> {s}");
                    }
                })
                .Wait();
            Console.WriteLine($"### with soap test");
           var soapClient = new FruitsServiceSoapClient(FruitsServiceSoapClient.EndpointConfiguration.FruitsServiceSoap12);
            soapClient.TestAsync().ContinueWith(r =>
            {
             if (r.IsCompletedSuccessfully)
                {
                    string s = r.Result.Body.TestResult;
                    Console.WriteLine($">> {s}");
                }
            })
            .Wait();


        }
    }
}
