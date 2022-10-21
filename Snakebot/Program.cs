using DSharpPlus;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Extensions.Logging;
using DSharpPlus.SlashCommands;
using DSharpPlus.EventArgs;
using Snakebot.Commands;

namespace Server_Servant
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }
        static async Task MainAsync()
        {
            configjson config = getJSON().Result;
            DiscordClient discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = config.token,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged,
                MinimumLogLevel = LogLevel.Information,
            });
            discord.Ready += onclientready;//adds client ready event
            discord.GuildAvailable += Client_GuildAvailable;//add guilds avilable event
            discord.ClientErrored += Client_ClientError;//adds client error event
            await discord.ConnectAsync();
            var slash = discord.UseSlashCommands();
            slash.RegisterCommands<slashcommands>();
            await Task.Delay(-1);
        }

        static async Task<configjson> getJSON()
        {
            string json = string.Empty;//will store json
            using (FileStream fs = File.OpenRead("config.json"))
            {
                using (StreamReader sr = new StreamReader(fs, new UTF8Encoding(false)))
                {
                    json = await sr.ReadToEndAsync();//loads json as string
                }
            }

            configjson configjson = JsonConvert.DeserializeObject<configjson>(json);//configures json to class
            return configjson;
        }
        private static Task onclientready(DiscordClient client, ReadyEventArgs e)
        {
            Console.WriteLine("Client is ready to process events.");
            return Task.CompletedTask;
        }
        private static Task Client_GuildAvailable(DiscordClient client, GuildCreateEventArgs e)
        {
            Console.WriteLine("Guild Avaiable: " + e.Guild.Name);
            return Task.CompletedTask;
        }

        private static Task Client_ClientError(DiscordClient client, ClientErrorEventArgs e)
        {
            Console.WriteLine("Exception occured: " + e.Exception.GetType() + ": " + e.Exception.Message);
            return Task.CompletedTask;
        }
    }
}
