using Production.Plugins.RyanScriptableObjects.SOReferences.FloatReference;
using Production.Plugins.RyanScriptableObjects.SOReferences.GameObjectListReference;
using Production.Scripts.Components;
using UnityEngine;

namespace Production.Scripts.Events
{
    public class EventEndGame : MonoBehaviour
    {
        public FloatReference Timer;
        public Animator _animator;
    
        public GameObjectListReference SpawnList;

        private void Update()
        {
            EndAnim();
            End();
        }
    
        private void End()
        {
            if (Timer.Variable.Value <= 1)
            {
                for (int i = 0; i < SpawnList.Variable.Value.Count; i++)
                {
                    SpawnList.Value[i].SetActive(false);
                }
            }
        }

        private void EndAnim()
        {
            if (Timer.Variable.Value <=3)
            {
                _animator.SetBool("EndGame", true);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.parent.gameObject.CompareTag("Player"))
            {
                Debug.Log("Tu est mort voila");
                other.GetComponent<HealthComponent>().playerDead.Raise(other.gameObject);
            }
        }
    }
}
