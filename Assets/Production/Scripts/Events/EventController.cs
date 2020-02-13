using System;
using Production.Plugins.RyanScriptableObjects.SOEvents.VoidEvents;
using Production.Plugins.RyanScriptableObjects.SOReferences.BoolReference;
using Production.Plugins.RyanScriptableObjects.SOReferences.FloatReference;
using Production.Plugins.RyanScriptableObjects.SOReferences.GameObjectReference;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Production.Scripts.Events {
    public class EventController : MonoBehaviour {

        [Header("Parameters")] 
        public float WindForce;

        [Header("Internal References")] 
        public Animator DeathLimitAnimator;
        public GameObject LeftWindEffect;
        public GameObject RightWindEffect;
        
        [Header("SO Reference")]
        public FloatReference PlayerMouvement;
        public GameObjectReference PlayerAGameObject;
        public GameObjectReference PlayerBGameObject;
        public GameObjectReference PlayerCGameObject;
        public GameObjectReference PlayerDGameObject;
        public BoolReference IsLevelScrolling;
        public BoolReference SpawnActive;
        
        [Header("SO Events")]
        public VoidEvent OnStartGameFinished;
        public VoidEvent OnEndGameFinished;
        public VoidEvent OnControlInversionFinished;
        public VoidEvent OnWindIsFinished;
        public VoidEvent OnLightOffIsFinished;
        
        private float _currentTimer;
        private float _endTimer;
        private Action _endTimeAction;
        private Action _updateAction;

        private float _deathLimitSmoothFactor;
        private Vector3 _deathLimitTargetPosition;

        private void Update() {
            _currentTimer += Time.deltaTime;
            _updateAction?.Invoke();
            if (_currentTimer > _endTimer && _endTimeAction != null) {
                _endTimeAction.Invoke();
                _endTimeAction = null;
            }
        }

        public void LaunchStartGame(int time) {
            LaunchEvent(time, delegate {
                IsLevelScrolling.Value = true;
                OnStartGameFinished.Raise();
            });
            DeathLimitAnimator.SetTrigger("StartGame");
            DeathLimitAnimator.speed = (float) 1 / time;
            IsLevelScrolling.Value = false;
        }
        
        public void LaunchEndGame(int time) {
            LaunchEvent(time, delegate {
                PlayerAGameObject.Value.SetActive(false);
                PlayerBGameObject.Value.SetActive(false);
                PlayerCGameObject.Value.SetActive(false);
                PlayerDGameObject.Value.SetActive(false);
                OnEndGameFinished.Raise();
            });
            SpawnActive.Value = false;
            DeathLimitAnimator.SetTrigger("EndGame");
            DeathLimitAnimator.speed = (float) 1 / time;
            IsLevelScrolling.Value = false;
        }
        
        public void LaunchControlInversion(int time) {
            LaunchEvent(time, delegate {
                PlayerMouvement.Value = 1;
                OnControlInversionFinished.Raise();
            });
            PlayerMouvement.Value = -1;
        }

        public void LaunchLightOff(int time) {
            LaunchEvent(time, delegate {
                OnLightOffIsFinished.Raise();
            });
        }

        public void LaunchWind(int time) {
            int direction = Random.value < .5 ? 1 : -1;
            Vector3 windEffect = WindForce * direction * Vector3.right;
            LaunchEvent(time, delegate {
                RightWindEffect.SetActive(false);
                LeftWindEffect.SetActive(false);
                _updateAction = null;
                OnWindIsFinished.Raise();
            }, delegate {
                PlayerAGameObject.Value.GetComponent<Rigidbody2D>().AddForce(windEffect * Time.deltaTime, ForceMode2D.Impulse);
                PlayerBGameObject.Value.GetComponent<Rigidbody2D>().AddForce(windEffect * Time.deltaTime, ForceMode2D.Impulse);
                PlayerCGameObject.Value.GetComponent<Rigidbody2D>().AddForce(windEffect * Time.deltaTime, ForceMode2D.Impulse);
                PlayerDGameObject.Value.GetComponent<Rigidbody2D>().AddForce(windEffect * Time.deltaTime, ForceMode2D.Impulse);
                Debug.Log("Wind : " + windEffect.x + " " + windEffect.y + " " + windEffect.z);
            });
            LeftWindEffect.SetActive(direction > 0);
            RightWindEffect.SetActive(direction < 0);
        }
        
        private void LaunchEvent(float time, Action endTimeAction = null, Action updateAction = null) {
            _currentTimer = 0;
            _endTimer = time;
            _endTimeAction = endTimeAction;
            _updateAction = updateAction;
        }
    
    }
}