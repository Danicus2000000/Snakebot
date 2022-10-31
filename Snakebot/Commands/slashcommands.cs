using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
namespace Snakebot.Commands
{
    public class slashcommands : ApplicationCommandModule
    {
        [SlashCommand("logout","Logs out the bot (Requires Admin)")]
        [SlashRequireUserPermissions(DSharpPlus.Permissions.Administrator)]
        public async Task logout(InteractionContext ctx) 
        {
            await ctx.CreateResponseAsync("Snakebot has logged out!");//goodbye message
            await ctx.Client.DisconnectAsync();//disconnect client
            Environment.Exit(0);//kill program
        }

        [SlashCommand("Help", "Explains what the bot can do (Requires Admin)!")]
        [SlashRequireUserPermissions(DSharpPlus.Permissions.Administrator)]
        public async Task help(InteractionContext ctx)
        {
            await ctx.CreateResponseAsync("Snakebot has one command:\n/logout - (Requires Server Administrator) Logs out the bot and terminates the local client");//goodbye message
        }
    }
}
