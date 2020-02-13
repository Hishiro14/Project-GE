using Production.Plugins.RyanScriptableObjects.SOReferences.BoolReference;
using Production.Plugins.RyanScriptableObjects.SOReferences.FloatReference;
using TMPro;
using UnityEngine;

namespace Collaborators_Folder.Aaron.Scripts
{
    public class PlayerPanelUI : MonoBehaviour
    {

        [Header("SO References")]
        public FloatReference TimerReference;
        public BoolReference PlayerAPlayReference;
        public FloatReference PlayerAScoreReference;
        public BoolReference PlayerBPlayReference;
        public FloatReference PlayerBScoreReference;
        public BoolReference PlayerCPlayReference;
        public FloatReference PlayerCScoreReference;
        public BoolReference PlayerDPlayReference;
        public FloatReference PlayerDScoreReference;

        [Header("Internal References")]
        public TextMeshProUGUI TimerText;
        public GameObject PlayerAStartGO;
        public GameObject PlayerAScoreGO;
        public TextMeshProUGUI PlayerAScoreText;
        public GameObject PlayerBStartGO;
        public GameObject PlayerBScoreGO;
        public TextMeshProUGUI PlayerBScoreText;
        public GameObject PlayerCStartGO;
        public GameObject PlayerCScoreGO;
        public TextMeshProUGUI PlayerCScoreText;
        public GameObject PlayerDStartGO;
        public GameObject PlayerDScoreGO;
        public TextMeshProUGUI PlayerDScoreText;

        //[Header("Prefabs")]

        // Update is called once per frame
        private void Update()
        {
            TimerText.text = TimerReference.Value.ToString();
            PlayerAStartGO.SetActive(!PlayerAPlayReference.Value);
            PlayerAScoreGO.SetActive(PlayerAPlayReference.Value);
            PlayerAScoreText.text = PlayerAScoreReference.Value.ToString();
            PlayerBStartGO.SetActive(!PlayerBPlayReference.Value);
            PlayerBScoreGO.SetActive(PlayerBPlayReference.Value);
            PlayerBScoreText.text = PlayerBScoreReference.Value.ToString();
            PlayerCStartGO.SetActive(!PlayerCPlayReference.Value);
            PlayerCScoreGO.SetActive(PlayerCPlayReference.Value);
            PlayerCScoreText.text = PlayerCScoreReference.Value.ToString();
            PlayerDStartGO.SetActive(!PlayerDPlayReference.Value);
            PlayerDScoreGO.SetActive(PlayerDPlayReference.Value);
            PlayerDScoreText.text = PlayerDScoreReference.Value.ToString();
        }

    }
}
