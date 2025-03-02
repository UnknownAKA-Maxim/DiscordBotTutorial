using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Commands.Admin
{
    public class AdminCommand : ModuleBase<SocketCommandContext>
    {
        [Command("Timeout")]
        [Summary("Gives Maxim Admin")]
        public async Task ExecuteAsync([Remainder][Summary("A phrase")] string phrase)
        {
            if (string.IsNullOrEmpty(phrase))
            {
                await ReplyAsync($"Usage: !Admin <phrase>");
                
                return;
            }

            await ReplyAsync($"/timeout user:{phrase} duration:60 secs reason:cos screw u leo");
        }
    }
}
