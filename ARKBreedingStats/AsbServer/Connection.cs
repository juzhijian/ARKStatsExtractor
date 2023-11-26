﻿using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using ARKBreedingStats.importExportGun;
using ARKBreedingStats.Library;

namespace ARKBreedingStats.AsbServer
{
    /// <summary>
    /// Connects to a server to receive creature data, e.g. sent by the export gun mod.
    /// </summary>
    internal static class Connection
    {
        private const string ApiUri = "https://export.arkbreeder.com/api/v1/";

        /// <summary>
        /// Currently used token for the server connection.
        /// </summary>
        private static string _token;

        private static bool _stopListening;

        public static async void StartListeningAsync(IProgress<(string jsonText, string serverHash, string message)> progressDataSent, string token = null)
        {
            if (string.IsNullOrEmpty(token)) return;
            _token = token;

            _stopListening = false;

            try
            {
                using (var client = new HttpClient())
                using (var stream = await client.GetStreamAsync(ApiUri + "listen/" + _token))
                using (var reader = new StreamReader(stream))
                {
#if DEBUG
                    Console.WriteLine($"Now listening using token: {_token}");
#endif
                    while (!_stopListening)
                    {
                        var received = await reader.ReadLineAsync();
                        if (_stopListening) break;
#if DEBUG
                        Console.WriteLine(received);
#endif
                        switch (received)
                        {
                            case "event: welcome":
                                continue;
                                break;
                            case "event: ping":
                                continue;
                                break;
                            case "event: replaced":
                                _stopListening = true;
                                progressDataSent.Report((null, null, "Connection used by a different user"));
                                return;
                            case "event: closing":
                                _stopListening = true;
                                progressDataSent.Report((null, null, "Connection closed by the server"));
                                return;
                        }

                        if (received != "event: export" && !received.StartsWith("event: server"))
                        {
                            Console.WriteLine("unknown server event: {received}");
                            continue;
                        }

                        received += "\n" + await reader.ReadLineAsync();
                        var m = _eventRegex.Match(received);
                        if (m.Success)
                        {
                            switch (m.Groups[1].Value)
                            {
                                case "export":
                                    progressDataSent.Report((m.Groups[3].Value, null, null));
                                    break;
                                case "server":
                                    progressDataSent.Report((m.Groups[3].Value, m.Groups[2].Value, null));
                                    break;
                            }
                        }
                    }
#if DEBUG
                    Console.WriteLine($"Stopped listening using token: {_token}");
#endif
                }
            }
            catch
            {
                // handle
            }
        }

        private static Regex _eventRegex = new Regex(@"^event: (welcome|ping|replaced|export|server|closing)(?: (\-?\d+))?(?:\ndata:\s(.+))?$");

        public static void StopListening()
        {
            _stopListening = true;
        }

        /// <summary>
        /// Sends creature data to the server, this is done for testing, usually other tools like the export gun mod do this.
        /// </summary>
        public static async void SendCreatureData(Creature creature, string token)
        {
            if (creature == null || string.IsNullOrEmpty(token)) return;
            _token = token;

            using (var client = new HttpClient())
            {
                var contentString = Newtonsoft.Json.JsonConvert.SerializeObject(ImportExportGun.ConvertCreatureToExportGunFile(creature, out _));
                var msg = new HttpRequestMessage(HttpMethod.Put, ApiUri + "export/" + _token);
                msg.Content = new StringContent(contentString, Encoding.UTF8, "application/json");
                msg.Content.Headers.Add("Content-Length", contentString.Length.ToString());
                var response = await client.SendAsync(msg);
                Console.WriteLine($"Sent creature data of {creature} using token: {_token}\nContent:\n{contentString}");
                Console.WriteLine(msg.ToString());
                Console.WriteLine($"Response: Status: {(int)response.StatusCode}, ReasonPhrase: {response.ReasonPhrase}");
            }
        }

        public static string CreateNewToken()
        {
            var allowedCharacters = Enumerable.Range(0x31, 9) // 1-9
                .Concat(Enumerable.Range(0x61, 8)) // a-h
                .Concat(new[] { 0x6b, 0x6d, 0x6e }) // k, m, n
                .Concat(Enumerable.Range(0x70, 11)) // p-z
                .Select(i => (char)i)
                .ToArray();
            var l = allowedCharacters.Length;

            var guid = Guid.NewGuid().ToByteArray();
            const int tokenLength = 14; // from these each 5th character is a dash for readability
            var token = new char[tokenLength];
            for (var i = 0; i < tokenLength; i++)
            {
                if ((i + 1) % 5 == 0)
                {
                    token[i] = '-';
                    continue;
                }
                token[i] = allowedCharacters[guid[i] % l];
            }

            return new string(token);
        }
    }
}
