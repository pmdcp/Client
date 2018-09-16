﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Constants;
using Unosquare.Labs.EmbedIO.Modules;

namespace Client.Logic.Music.YouTube
{
    public class YouTubeAudioPlayer
    {
        public static YouTubeAudioPlayer Instance { get; set; }

        Form audioPlayerForm;
        WebBrowser webBrowser;

        WebServer server;

        int port;

        string playingSongID;

        public YouTubeAudioPlayer()
        {
            audioPlayerForm = new Form();

            webBrowser = new WebBrowser();
            audioPlayerForm.Controls.Add(webBrowser);

            // Initialize the form and generate the active-x control without displaying the form
            // Yes, it's a hack
            var ptr = audioPlayerForm.Handle;

            StartWebserver();
        }

        private delegate void PlayDelegate(string id);
        public void Play(string id)
        {
            if (audioPlayerForm.InvokeRequired)
            {
                audioPlayerForm.Invoke(new PlayDelegate(Play), id);
                return;
            }

            if (IO.Options.Music == false)
            {
                Stop();
                return;
            }

            if (string.Equals(id, playingSongID))
            {
                return;
            }

            playingSongID = id;

            webBrowser.Navigate($"http://localhost:{port}/v/{id}");
        }

        private delegate void StopDelegate();
        public void Stop()
        {
            if (audioPlayerForm.InvokeRequired)
            {
                audioPlayerForm.Invoke(new StopDelegate(Stop));
                return;
            }

            playingSongID = "";

            webBrowser.DocumentText = "";
        }

        private void StartWebserver()
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();

            port = ((IPEndPoint)listener.LocalEndpoint).Port;

            listener.Stop();

            server = new WebServer($"http://localhost:{port}/", RoutingStrategy.Regex);

            server.RegisterModule(new WebApiModule());
            server.Module<WebApiModule>().RegisterController<YouTubeHTMLController>();

            server.RunAsync();
        }
    }
}
