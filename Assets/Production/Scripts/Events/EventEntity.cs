using System;
using System.Collections.Generic;
using Production.Plugins.RyanScriptableObjects.SOEvents.IntEvents;
using Production.Plugins.RyanScriptableObjects.SOEvents.VoidEvents;
using Production.Plugins.RyanScriptableObjects.SOReferences.BoolReference;
using Production.Plugins.RyanScriptableObjects.SOReferences.FloatReference;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Production.Scripts.Events {
    public class EventEntity : MonoBehaviour {

        [Header("SO Events")]
        public List<EventCouple> RandomizedEvents = new List<EventCouple>();
        public EventCouple OnStartGame;
        public EventCouple OnEndGame;

        [Header("SO References")] 
        public BoolReference HasGameStarted;
        public FloatReference CurrentTime;
        
        [Header("Fixed Events Management")]
        public int CooldownBeforeStart;
        public int CooldownBeforeEnd;
        
        [Header("Random Events Management")]
        public AnimationCurve ProbabilityCurve;
        public float RandFrequency;
        public int MinDuration;
        public int MaxDuration;
        
        private float _probabilityIncrement;
        private float _eventTimer;
        private float _randTimer;
        private float _proba;
        private EventCouple _currentEventCouple;
        private bool _isGameEnding;
        
        private void Start() {
            _eventTimer = 0;
            _proba = 0;
        }

        private void Update() {
            if (CurrentTime.Value <= CooldownBeforeEnd && !_isGameEnding) {
                OnEndGame.OnLaunchEvent.Raise(CooldownBeforeEnd);
                _isGameEnding = true;
            }
            else {
                ComputeEventProbability();
            }
        }

        public void StartGame() {
            if (!HasGameStarted) {
                HasGameStarted.Value = true;
                OnStartGame.OnLaunchEvent.Raise(CooldownBeforeStart);
            }
        }

        private void ComputeEventProbability() {
            _eventTimer += Time.deltaTime;
            _randTimer += Time.deltaTime;
            if (_randTimer > RandFrequency) {
                _randTimer = 0;
                _proba = Random.Range(0f, 1f);
            }
            _probabilityIncrement = ProbabilityCurve.Evaluate(_eventTimer);
            if (_proba >= _probabilityIncrement) {
                TriggerEvent();
                _proba = 0;
                _eventTimer = 0;
            }
        }

        private void TriggerEvent() {
            _currentEventCouple = RandomizedEvents[Random.Range(0, RandomizedEvents.Count)];
            int eventDuration = Random.Range(MinDuration, MaxDuration);
            _currentEventCouple.OnLaunchEvent.Raise(eventDuration);
            Debug.Log("Event Triggered : " + _currentEventCouple.OnLaunchEvent.name + " for " + eventDuration + " seconds");
        }

    }

    [Serializable]
    public struct EventCouple {
        public IntEvent OnLaunchEvent;
        public VoidEvent OnFinishedEvent;
    }

}