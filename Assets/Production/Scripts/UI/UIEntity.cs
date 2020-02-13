using System;
using System.Collections.Generic;
using System.Linq;
using Production.Plugins.RyanScriptableObjects.SOReferences.BoolReference;
using Production.Plugins.RyanScriptableObjects.SOReferences.FloatReference;
using Production.Plugins.RyanScriptableObjects.SOReferences.GameObjectReference;
using Production.Plugins.RyanScriptableObjects.SOReferences.StringReference;
using Production.Scripts.Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Production.Scripts
{
    public class UIEntity : MonoBehaviour
    {
        [Header("Player Timer")]
        public TextMeshProUGUI TimerText;
        public FloatReference Timer;

        [Header("Instanciation")]
        public GameObject BonusPrefab;
    
        public List<PlayerInfo> PlayerInfos = new List<PlayerInfo>();
        // Start is called before the first frame update
        void Start()
        {
            foreach (var pInfo in PlayerInfos)
            {
                pInfo.NamePlayerText.text = pInfo.NamePlayer.Value;
            }
        }

        void ManagePanelsOnPlayerActivness()
        {
            foreach (var pInfo in PlayerInfos)
            {
                pInfo.PanelPlayer.SetActive(pInfo.IsActivePlayer);
            }
        }
        // Update is called once per frame
        void Update()
        {
            TimerText.text = Mathf.RoundToInt(Timer.Value).ToString();
            foreach (var pInfo in PlayerInfos)
            {
                pInfo.ScorePlayerText.text = Mathf.RoundToInt(pInfo.ScorePlayer.Value).ToString();
            }
            ManagePanelsOnPlayerActivness();
        }

        public void ManagerBonus(GameObject player) {
            PlayerInfo firstOrDefault = PlayerInfos.FirstOrDefault(info => info.Player.Value == player);
            UpdatePlayerInfos(firstOrDefault, BonusPrefab);
        }

        private static void UpdatePlayerInfos(PlayerInfo playerInfo, GameObject bonusPrefab) {

            if(playerInfo.ActiveBonusesPlayer.Count>0){
                foreach (var obj in playerInfo.ActiveBonusesPlayer) 
                { 
                    Debug.Log("Remove Bonus And Destroy  Icon");
                    Destroy(obj);
                }
            }
            playerInfo.ActiveBonusesPlayer.Clear();
            BonusHandlerComponent bonusComponent = playerInfo.Player.Value.GetComponent<BonusHandlerComponent>();
            foreach (var durItem in bonusComponent.AvalaibleDurationItem) {
                var instantiatedBonusIcon = Instantiate(bonusPrefab, playerInfo.BonusPanel.transform);
                instantiatedBonusIcon.transform.GetChild(0).GetComponentInChildren<Image>().sprite = durItem.ItemIcon;
                playerInfo.ActiveBonusesPlayer.Add(instantiatedBonusIcon);
            }
            foreach (var unDeItem in bonusComponent.AvalaibleUntilDeathItem) {
                Debug.Log("Instantiate Icon ");
                var instantiatedBonusIcon = Instantiate(bonusPrefab, playerInfo.BonusPanel.transform);
                instantiatedBonusIcon.transform.GetChild(0).GetComponentInChildren<Image>().sprite = unDeItem.ItemIcon;
                playerInfo.ActiveBonusesPlayer.Add(instantiatedBonusIcon);
            } 
        }

        [Serializable]
        public class PlayerInfo {
            public FloatReference ScorePlayer;
            public StringReference NamePlayer;
            public GameObjectReference Player;
            public TextMeshProUGUI ScorePlayerText;
            public TextMeshProUGUI NamePlayerText;
            public BoolReference IsActivePlayer;
            public GameObject PanelPlayer;
            public GameObject BonusPanel;
            public List<GameObject> ActiveBonusesPlayer = new List<GameObject>();
        }
    
    }
}
