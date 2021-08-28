using UnityEngine;

namespace HourChallenge.Storage
{
    public abstract class Preferences
    {
        const string KEY_CURRENT_CHALLENGE = "__CURRENT_CHALLENGE__";
        const string KEY_AUDIO = "__AUDIO__";
        const string KEY_MUSIC = "__MUSIC__";        
        const string KEY_VIBRATION = "__VIBRATION__";

        public static int CurrentChallenge => PlayerPrefs.GetInt(KEY_CURRENT_CHALLENGE, 1);
        public static void SetCurrentChallenge(int value) => PlayerPrefs.SetInt(KEY_CURRENT_CHALLENGE, value);
        
        public static bool HasAudio => PlayerPrefs.GetInt(KEY_AUDIO, 1) == 1;
        public static void SetAudio(bool value) => PlayerPrefs.SetInt(KEY_AUDIO, value ? 1 : 0);

        public static bool HasMusic => PlayerPrefs.GetInt(KEY_MUSIC, 1) == 1;
        public static void SetMusic(bool value) => PlayerPrefs.SetInt(KEY_MUSIC, value ? 1 : 0);

        public static bool HasVibration => PlayerPrefs.GetInt(KEY_VIBRATION, 1) == 1;
        public static void SetVibration(bool value) => PlayerPrefs.SetInt(KEY_VIBRATION, value ? 1 : 0);
    }
}
