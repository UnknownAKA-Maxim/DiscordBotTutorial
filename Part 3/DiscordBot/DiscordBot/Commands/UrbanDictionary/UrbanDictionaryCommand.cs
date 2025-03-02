using System.Net.Http.Headers;
using System.Text.Json;
using Discord;
using Discord.Commands;


namespace DiscordBot.Commands.UrbanDictionary
{
    public class UrbanDictionaryCommand : ModuleBase<SocketCommandContext>
    {
        private readonly HttpClient _httpClient;

        public UrbanDictionaryCommand()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "DiscordBot");
        }

        [Command("ud")]
        [Summary("Looks up the phrase using the UrbanDictionary.com API")]
        public async Task ExecuteAsync([Remainder][Summary("A phrase")] string phrase)
        {
            if (string.IsNullOrEmpty(phrase))
            {
                await ReplyAsync("Usage: !ud <phrase>");
                return;
            }

            try
            {
                phrase = Uri.EscapeDataString(phrase);

                var response = await _httpClient.GetStringAsync($"http://api.urbandictionary.com/v0/define?term={phrase}");
                if (phrase == "joshua"||phrase=="Joshua")
                {
                    await ReplyAsync($"A guy who Likes to gargle on nuts");
                    return;
                }
                if (phrase == "Leo%20Ellerton")
                {
                    await ReplyAsync("Fat neek who mum fuck with dead people");
                    return;
                }
                if (phrase =="CallJoshFat")
                {
                    await ReplyAsync("okay");
                    await ReplyAsync("@287997747662028800 you are fat");
                    return;
                }
                if(phrase == "josh" || phrase == "Josh")
                {
                    await ReplyAsync("Josh is either a huge prick who wont give me admin who is pushing twenty(Josh Whiteley)  or a normal guy whos pretty chill (Josh Ryan)");
                    return;
                }
                if (string.IsNullOrEmpty(response))
                {
                    await ReplyAsync($"Nothing found for {phrase}");
                    return;
                }

                var jsonOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                var result = JsonSerializer.Deserialize<UrbanDictionaryResponse>(response, jsonOptions);

                if (result?.List == null || result.List.Count == 0)
                {
                    await ReplyAsync($"No definition found for {phrase}");
                }
                else
                {
                    await ReplyAsync($"_{phrase}?_");
                    await ReplyAsync(result.List[0].Definition);
                }
            }
            catch (HttpRequestException)
            {
                await ReplyAsync("Error making the request to Urban Dictionary API");
            }
            catch (Exception ex)
            {
                await ReplyAsync($"An error occurred: {ex.Message}");
            }
        }
    }

    public class UrbanDictionaryResponse
    {
        public List<UrbanDictionaryItem>? List { get; set; }
    }

    public class UrbanDictionaryItem
    {
        public string? Definition { get; set; }
    }
}