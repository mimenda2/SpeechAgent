using System;
using System.IO;

namespace SpeechAgent.TTSObjects
{
    public static class SpeechUtils
    {
        public static string GetTempPathFileName(string fileName = "", string extension = "")
        {
            if (extension != null && extension.StartsWith("."))
            {
                extension = extension.Replace(".", "");
            }
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                $"{(!string.IsNullOrEmpty(fileName) ? fileName : DateTime.Now.Ticks.ToString())}{(!string.IsNullOrEmpty(extension) ? $".{extension}" : "")}");
        }
    }
}
