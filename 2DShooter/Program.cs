using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.Json;
using System.Xml.Linq;
using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;


namespace _2DShooter
{
    public class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player();
            player1.weapon1 = 'a';
            player1.weapon2 = 'b';
            player1.weapon3 = 'c';
            player1.item1 = 'd';
            player1.item2 = 'e';
            player1.totalPoints = 0;

            player1.name = "badassbob";

            Console.Clear();
            Console.WriteLine("name " + player1.name, "Total Points" + player1.totalPoints, "Item 1" + player1.item1, "Item 2" + player1.item2, "Weapon 1" + player1.weapon1, "Weapon2" + player1.weapon2, "Weapon 3" + player1.weapon3);

            // Add System Reflection component

            Console.WriteLine("--------------------");

            Console.WriteLine("Reflection Example");

            Type thisType = player1.GetType();

            Type weaponType = player1.weapon1.GetType();

            Type pointsType = player1.totalPoints.GetType();

            Console.WriteLine(thisType.Name);

            Console.WriteLine(weaponType.Name);

            Console.WriteLine(pointsType.Name);



            Console.WriteLine("--------------------");

            // Using Reflection to get information of an Assembly:

            System.Reflection.Assembly info = typeof(int).Assembly;

            Console.WriteLine(info);

            Console.ReadLine();

            Console.WriteLine("--------------------");

            Player.selectWeapon myObj = new Player.selectWeapon();

            myObj.chooseWeapon(5);

            Console.WriteLine("Weapon with 5 points {0}", myObj.newWeapon.ToString());

            myObj.chooseWeapon(10);

            Console.WriteLine("Weapon with 10 points {0}", myObj.newWeapon.ToString());

            Console.ReadLine();


            CallWhoAmI_API();
        }


           

            

           

            static void CallWhoAmI_API()
            {
                // Specify the Dataverse environment name to connect with.
                string resource = "https://org35646656.api.crm.dynamics.com";

                // Azure Active Directory app registration shared by all Power Apps samples.
                // For your custom apps, you will need to register them with Azure AD yourself.
                // See https://learn.microsoft.com/powerapps/developer/data-platform/walkthrough-register-app-azure-active-directory
                var clientId = "51f81489-12ee-4a9e-aaae-a2591f45987d";
                var redirectUri = "app://58145B91-0C36-4500-8554-080854F2AC97";

                #region Authentication
                var authBuilder = PublicClientApplicationBuilder.Create(clientId)
                                 .WithAuthority(AadAuthorityAudience.AzureAdMultipleOrgs)
                                 .WithRedirectUri(redirectUri)
                                 .Build();
                var scope = resource + "/.default";
                string[] scopes = { scope };

                AuthenticationResult token =
                    authBuilder.AcquireTokenInteractive(scopes).ExecuteAsync().Result;
                #endregion Authentication

                #region Client configuration

                var client = new HttpClient
                {
                    // See https://learn.microsoft.com/powerapps/developer/data-platform/webapi/compose-http-requests-handle-errors#web-api-url-and-versions
                    BaseAddress = new Uri(resource + "/api/data/v9.2/"),
                    Timeout = new TimeSpan(0, 2, 0)    // Standard two minute timeout on web service calls.
                };

                // Default headers for each Web API call.
                // See https://learn.microsoft.com/powerapps/developer/data-platform/webapi/compose-http-requests-handle-errors#http-headers
                HttpRequestHeaders headers = client.DefaultRequestHeaders;
                headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
                headers.Add("OData-MaxVersion", "4.0");
                headers.Add("OData-Version", "4.0");
                headers.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                #endregion Client configuration

                #region Web API call

                // Invoke the Web API 'WhoAmI' unbound function.
                // See https://learn.microsoft.com/powerapps/developer/data-platform/webapi/compose-http-requests-handle-errors
                // See https://learn.microsoft.com/powerapps/developer/data-platform/webapi/use-web-api-functions#unbound-functions
                var response = client.GetAsync("WhoAmI").Result;

                if (response.IsSuccessStatusCode)
                {
                    // Parse the JSON formatted service response to obtain the user ID.
                    JObject body = JObject.Parse(
                        response.Content.ReadAsStringAsync().Result);
                    Guid userId = (Guid)body["UserId"];

                    Console.WriteLine("Your user ID is {0}", userId);
                }
                else
                {
                    Console.WriteLine("Web API call failed");
                    Console.WriteLine("Reason: " + response.ReasonPhrase);
                }
                #endregion Web API call

                // Pause program execution by waiting for a key press.
                Console.ReadKey();
            }
        }
    }


        
    

