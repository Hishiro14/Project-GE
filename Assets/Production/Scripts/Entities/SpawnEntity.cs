using Production.Plugins.RyanScriptableObjects.SOEvents.VoidEvents;
using Production.Plugins.RyanScriptableObjects.SOReferences.BoolReference;
using Production.Plugins.RyanScriptableObjects.SOReferences.GameObjectListReference;
using Production.Scripts.Utils;
using UnityEngine;

namespace Production.Scripts.Entities
{
    public class SpawnEntity : MonoBehaviour
    {
        [SerializeField]Transform SpawnPoint;
        [SerializeField]GameObject player;
        public BoolReference OnPlayerActive;
        public BoolReference SpawnActive;
        public VoidEvent PlayerSpawn;
        
        void Awake()
        {
            player.GetComponent<PlayerEntity>().Name.Value = NameGenerator.GenerateName();
        
        }
        public void FirstSpawn()
        {
            if (SpawnActive.Value)
            {
                PlayerSpawn.Raise();
                OnPlayerActive.Value = true;
                player.GetComponent<ArrowComponent>().DisplayOnRespawn();
                player.transform.position = SpawnPoint.position;
            }
            else
            {
                Debug.Log("Spawn Unactive");
            }
        }

        
        public void Respawn(){
            if (SpawnActive.Value)
            {
                player.GetComponent<ArrowComponent>().DisplayOnRespawn();
                player.transform.position = SpawnPoint.position;
            }
            else
            {
                Debug.Log("Respawn Unactive");
            }
        }

    }
}
