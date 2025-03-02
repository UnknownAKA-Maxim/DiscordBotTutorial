using Discord.Commands;

namespace DiscordBot.Commands.EchoCommand
{
    public class EchoCommand : ModuleBase<SocketCommandContext>
    {
        [Command("simonsays")]
        [Summary("Echoes back what was said")]
        public async Task ExecuteAsync([Remainder][Summary("A phrase")] string phrase)
        {
            if (string.IsNullOrEmpty(phrase))
            {
                await ReplyAsync($"Usage: !simonsays <phrase>");
                return;
            }

            await ReplyAsync(phrase);
        }
    }
}