using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
namespace Snakebot.Commands
{
    public class slashcommands : ApplicationCommandModule
    {
        [SlashCommand("logout","Logs out the bot")]
        [SlashRequirePermissions(DSharpPlus.Permissions.Administrator)]
        public async Task logout(InteractionContext ctx) 
        {
            await ctx.CreateResponseAsync("Snakebot has logged out!");//goodbye message
            await ctx.Client.DisconnectAsync();//disconnect client
            Environment.Exit(0);//kill program
        }
    }
}
