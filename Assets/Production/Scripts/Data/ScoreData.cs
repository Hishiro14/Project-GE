using System;
using System.Collections.Generic;
using UnityEngine;

namespace Production.Scripts.Data
{
    [CreateAssetMenu(fileName = "ScoreData", menuName = "Data/ScoreData")]
    public class ScoreData : ScriptableObject
    {
        public List<ScoreDataEntry> ScoreList = new List<ScoreDataEntry>();
        public int PlayerNumberInLastGame;
        public void Reset()
        {
            ScoreList.Clear();
        }

        public void Display()
        {
            foreach (var Entry in ScoreList)
            {
                Debug.Log(Entry.PlayerName + " Obtained" + Entry.Score + " Points");
            }
        }
    }

    [Serializable]
    public struct ScoreDataEntry
    {
        public string PlayerName;
        public float Score;
        public int PlayerID;
    }
}