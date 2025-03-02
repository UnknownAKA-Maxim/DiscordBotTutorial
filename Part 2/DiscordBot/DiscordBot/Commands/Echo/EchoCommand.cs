﻿using Discord.Commands;

namespace DiscordBot.Commands.EchoCommand
{
    public class EchoCommand : ModuleBase<SocketCommandContext>
    {
        [Command("echo")]//!echo hello
        [Summary("Echoes back what was said")]
        public async Task ExecuteAsync([Remainder][Summary("A phrase")] string phrase)
        {
            if (string.IsNullOrEmpty(phrase))
            {
                await ReplyAsync($"Usage: !echo <phrase>");
                return;
            }

            await ReplyAsync(phrase);
        }
    }
}