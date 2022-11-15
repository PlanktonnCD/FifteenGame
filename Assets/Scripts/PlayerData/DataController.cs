using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace PlayerData
{
    public class DataController
    {
        private static readonly string DATAPATH = (Application.persistentDataPath + "/PlayerData.json");

        public static void SaveIntoJson(HighScoreData highScoreData)
        {
            var output = JsonConvert.SerializeObject(highScoreData);
            File.WriteAllText(DATAPATH, output);
        }

        public static HighScoreData ReadFromJson()
        {
            if (!File.Exists(DATAPATH))
            {
                File.WriteAllText(DATAPATH, String.Empty);
            }
            var input = File.ReadAllText(DATAPATH);
            return JsonConvert.DeserializeObject<HighScoreData>(input);
        }
    }
}