﻿namespace ARKBreedingStats.AsbServer
{
    /// <summary>
    /// Info of progress reports while listening to an AsbServer.
    /// </summary>
    internal class ProgressReportAsbServer
    {
        public string JsonText;
        public string ServerHash;
        public string Message;
        public string ServerToken;
        public bool IsError;
        public bool StopListening;
        public string ClipboardText;
    }
}
