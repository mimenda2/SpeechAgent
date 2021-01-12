using SpeechAgent.Interfaces;
using System;

namespace SpeechAgent.Enum
{
    public enum TTS_EnumObjects
    {
        TTS_SpeechSynthesizer = 1,
        TTS_SpVoice = 2,
        TTS_AmazonPolly = 3,
        TTS_MSAgent = 4,
        TTS_GoogleTranslator = 5
    }
    public static class TTSObject
    {
        public static ITTS CreateObject(TTS_EnumObjects type, string user, string password)
        {
            return (ITTS)Activator.CreateInstance(GetTTSType(type), new object[] { user, password});
        }
        public static Type GetTTSType(TTS_EnumObjects type)
        {
            return Type.GetType($"SpeechAgent.TTSObjects.{type.ToString()}");
        }
    }
}
