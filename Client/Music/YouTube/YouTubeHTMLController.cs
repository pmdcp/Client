using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Constants;
using Unosquare.Labs.EmbedIO.Modules;

namespace Client.Logic.Music.YouTube
{
    public class YouTubeHTMLController : WebApiController
    {
        const string page = @"<html>
    <head>
        <!-- Use latest version of IE -->
        <meta http-equiv=""X-UA-Compatible"" content=""IE=Edge"" />
        <title></title>
    </head>
    <body>{0}</body>
</html>";

        [WebApiHandler(HttpVerbs.Get, "/v/{id}")]
        public async Task<bool> GetThing(WebServer server, HttpListenerContext context, string id)
        {
            var embedUrl = GenerateEmbedUrl(id, true);
            var result = string.Format(page, $"<iframe width=\"500\" height=\"500\" src=\"{embedUrl}\" frameborder=\"0\" allow=\"autoplay; encrypted-media\" allowfullscreen></iframe>");

            await context.HtmlResponseAsync(result);
            return true;
        }

        private string GenerateEmbedUrl(string id, bool loop)
        {
            var embedUrlBuilder = new StringBuilder();

            embedUrlBuilder.Append($"https://www.youtube.com/embed/{id}?autoplay=1");

            if (loop)
            {
                embedUrlBuilder.Append("&loop=1");
                // Workaround for YouTube player bug: https://developers.google.com/youtube/player_parameters
                embedUrlBuilder.Append($"&playlist={id}");
            }

            return embedUrlBuilder.ToString();
        }
    }
}
