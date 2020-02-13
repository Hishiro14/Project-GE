using Production.Plugins.RyanScriptableObjects.SOReferences.FloatReference;
using UnityEngine;

namespace Production.Scripts.Components
{
    public class ScoreComponent : MonoBehaviour
    {
        private IScore _score;
        public AnimationCurve ScoreIncrementCurve;
        public float ScoreIncrement;
        public float incrementTimer;
        public float CountScore;
        private void Awake()
        {
            _score = GetComponent<IScore>();
            _score.playerScore.Value = 0;
        }

        private void Update()
        {
            ComputeScore();
        }

        void ComputeScore()
        {
            incrementTimer += Time.deltaTime;
            incrementTimer = Mathf.Clamp(incrementTimer, 0f, 10f);
            ScoreIncrement = ScoreIncrementCurve.Evaluate(incrementTimer);
            _score.playerScore.Value += (10*ScoreIncrement * Time.deltaTime);
        }
    }

    interface IScore
    {
        FloatVariable playerScore { get; }
    }
}