using System.Collections.Generic;
using Production.Scripts.Data;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Production.Scripts.Entities
{
    public class ScoreMenuEntity : MonoBehaviour
    {
        public GameObject ScoreInputPrefab;
        public ScoreData ScoreData;
        [SerializeField] private List<GameObject> ScoreEntries = new List<GameObject>();
        public Transform ViewPortContent;

        public List<GameObject> PlayersScorePanels = new List<GameObject>();
        public List<ScoreDataEntry> LastPlayers = new List<ScoreDataEntry>();
      private void Start()
        {
            DisplayScore(ScoreData.PlayerNumberInLastGame);
            InitializeGeneralScores();
        }

        void InitializeGeneralScores()
        {
            
            foreach (var obj in ScoreEntries)
            {
                obj.SetActive(false);
            }
            List<ScoreDataEntry> BestScores = new List<ScoreDataEntry>();
            if (ScoreData.ScoreList.Count < 10)
            {
                for (int i = 0; i < ScoreData.ScoreList.Count; i++)
                {
                    BestScores.Add(ScoreData.ScoreList[i]);
                }
            }

            if (ScoreData.ScoreList.Count >= 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    BestScores.Add(ScoreData.ScoreList[i]);
                }
            }
            BestScores.Sort(delegate(ScoreDataEntry entry, ScoreDataEntry dataEntry)
            {
                return entry.Score.CompareTo(dataEntry.Score);});
            BestScores.Reverse();
            Debug.Log(BestScores.Count);
            for (int i = 0; i < BestScores.Count; i++)
            {
                ScoreEntries[i].SetActive(true);
                TextMeshProUGUI _nameText =
                    ScoreEntries[i].transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
                _nameText.text = BestScores[i].PlayerName;
                TextMeshProUGUI _scoreText =
                    ScoreEntries[i].transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
                _scoreText.text = Mathf.RoundToInt(BestScores[i].Score).ToString();
                _scoreText.color = Color.white;
                _nameText.color = Color.white;
                if (LastPlayers.Count > 0)
                {
                    if (LastPlayers.Exists(item => item.PlayerName == BestScores[i].PlayerName))
                    {
                        _nameText.color = Color.green;
                        _scoreText.color = Color.green;
                    }
                }
            }
        }
        public void DisplayScore(int NumberOfPlayer)
        {
            Debug.Log(NumberOfPlayer + " played last game and scored");
            //Reset
            foreach (var panel in PlayersScorePanels)
            {
                panel.SetActive(false);
            }
            int index = ScoreData.ScoreList.Count - NumberOfPlayer;
            for (int i = 0; i < NumberOfPlayer; i++)
            {
                LastPlayers.Add(ScoreData.ScoreList[index]);
                int PanelID = ScoreData.ScoreList[index].PlayerID;
                int Score = Mathf.RoundToInt(ScoreData.ScoreList[index].Score);
                string Name = ScoreData.ScoreList[index].PlayerName;
                Debug.Log(PanelID + Score + Name);
                PlayersScorePanels[PanelID].SetActive(true);
                PlayersScorePanels[PanelID].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Name;
                PlayersScorePanels[PanelID].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = Score.ToString();
                index++;

            }
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void Restart()
        {
            SceneManager.LoadScene(1);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
