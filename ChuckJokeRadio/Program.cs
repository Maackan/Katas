using System;
using System.Net.Http;
using System.Text.Json;

namespace ChuckJokeRadio
{
    class Program
    {
        //TODO plocka även ut och visa datumet för när skämtet skapades/senast uppdaterades
        /* Exempel på ett svar från servern
            {
              "categories": [],
              "created_at": "2020-01-05 13:42:23.484083",
              "icon_url": "https://assets.chucknorris.host/img/avatar/chuck-norris.png",
              "id": "cRcjbqJpQ-GMzIawRcvVlA",
              "updated_at": "2020-01-05 13:42:23.484083",
              "url": "https://api.chucknorris.io/jokes/cRcjbqJpQ-GMzIawRcvVlA",
              "value": //"The only time Chuck Norris felt sadness was when he read Nuck Chorris' jokes."
            }
        */
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();

            while (true)
            {
                string url = @"https://api.chucknorris.io/jokes/random";
                string json = client.GetStringAsync(url).Result;
                /* //Det nedanför är hämtat från jsonformatter.org. där jag klistrade in texten från skämthemsidan för att kunna sortera json texten.
                  {
               "categories": [],
              "created_at": "2020-01-05 13:42:23.240175",
              "icon_url": "https://assets.chucknorris.host/img/avatar/chuck-norris.png",
              "id": "QHx5U_sdTpCpbf4yO59miA",
              "updated_at": "2020-01-05 13:42:23.240175",
              "url": "https://api.chucknorris.io/jokes/QHx5U_sdTpCpbf4yO59miA",
              "value": "Once, while dining in a fancy New York restaurant, Chuck Norris discovered a fly in his soup. There were no survivors."
                   }
                 */


                string startTag = "\"value\":\"";
                int start = json.IndexOf(startTag) + startTag.Length;
                int end = json.IndexOf("\"}", start);

                string startTagDate = "\"created_at\":\"";
                int startDate = json.IndexOf(startTagDate) + startTagDate.Length;
                int endDate = json.IndexOf("\"", startDate);


                string date = json.Substring(startDate, endDate - startDate);
                DateTime dateTag = DateTime.Parse(date); //försök använda DateTime istället för att sedan kunna köra ToString("yy/mm/dd/HH:mm") osv

                
                

                 

                
                string joke = json.Substring(start, end - start);

                string dateString = "2020-01-05 13:42:23.484083";
                DateTime date = DateTime.Parse(dateString);

                Console.WriteLine(joke);
                //Console.WriteLine("\nThis Joke was added : " + dateTag.Year + "/" + dateTag.Month + "/" + dateTag.Day);
                Console.WriteLine("This joke was added : " + dateTag.ToString("yy'/'M'/'d"));
               

                Console.WriteLine();
                Console.Write("Press enter for another joke");
                Console.ReadLine();

                Console.Clear();
            }
        }
    }
}
