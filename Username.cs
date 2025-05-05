using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;

namespace Phoenix
{
    class Username
    {
        public static async Task MainUser(string answer)
        {
            Console.Clear();

            String filePath = "banner.txt";

            try
            {
                String content = File.ReadAllText(filePath);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(content);
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.Clear();
            }

            Console.Title = $"Phoenix | Scanning {answer}...";
            Console.WriteLine("\nYou have put the username " + answer + "\n");
            await Username.scan(answer);
        }

        private static async Task scan(string answer)
        {
            var platforms = new Dictionary<string, string>
            {
                // ill be targeting predetors with this

                { "Twitter", $"https://twitter.com/{answer}" },
                { "Instagram", $"https://www.instagram.com/{answer}" },
                { "GitHub", $"https://github.com/{answer}" },
                { "Reddit", $"https://www.reddit.com/user/{answer}" },
                { "Youtube", $"https://www.youtube.com/user/{answer}" },
                { "Tiktok", $"https://tiktok.com/@{answer}" },
                { "VK", $"https://vk.com/{answer}" },
                { "Linktree", $"https://linktr.ee/{answer)" },
                { "Telegram", $"https://t.me/{answer}" },
                { "Amino | May not work :( |", $"https://animoapps.com/u/{answer}"  },
                { "Threads", $"https://threads.net/@{answer}" },
                { "Snapchat", $"https://snapchat.com/add/{answer}" },
                { "Pinterest", $"https://pinterest.com/{answer}" },
                { "LinkedIn", $"https://linkedin.com/in/{answer}" },
                { "Mastodon", $"https://mastodon.social/@{answer}" },
                { "LINE", $"https://line.me/ti/p/{answer}" },
                { "KIK", $"https://kik.me/{answer}" },
                { "Lemon8", $"https://lemon8-app.com/{answer}" },
                { "Twitch", $"https://twitch.tv/{answer}" },
                { "SoundCloud", $"https://soundcloud.com/{answer}" },
                { "DeviantArt", $"https://deviantart.com/{answer}" },
                { "Bandcamp", $"https://{answer}.bandcamp.com" },
                { "Imgur", $"https://imgur.com/user/{answer}" },
                { "Patreon", $"https://patreon.com/{answer}" },
                { "Kickstarter", $"https://kickstarter.com/profile/{answer}" },
                { "Zynga", $"https://zynga.com/profile/{answer}" },
                { "Strava", $"https://strava.com/atheletes/{answer}" }
            };

            using (HttpClient client = new HttpClient())
            {
                foreach (var platform in platforms)
                {
                    try
                    {
                        Console.Title = $"Phoenix | Scanning {answer}...";

                        HttpResponseMessage response = await client.GetAsync(platform.Value);
                        if (response.IsSuccessStatusCode)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"[+] {platform.Key}: {platform.Value}");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"[-] {platform.Key}: {platform.Value}");
                            Console.ResetColor();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[error] {platform.Key}: {ex.Message}");
                    }
                }

                Console.Title = $"Phoenix | Done scanning {answer}!";
                Console.ReadLine();
            }
        }
    }
}
