using System.Collections.Generic;
using Production.Plugins.RyanScriptableObjects.SOReferences.FloatReference;
using Production.Plugins.RyanScriptableObjects.SOReferences.GameObjectListReference;
using Production.Plugins.RyanScriptableObjects.SOReferences.GameObjectReference;
using UnityEngine;

namespace Production.Scripts.Platforms
{
    public class SpawnPlatforms : MonoBehaviour
    {
        [Header("SO References")] 
        public FloatReference CurrentTimeReference; //Recupère depuis un SO le temps actuel
        public FloatReference EndTimeReference; //Recupère depuis un SO le temps actuel

        [Header("Difficulty Parameters")]
    
        public int DifficultyIndiceMax;
        public int DifficultyIndiceMin;
        public float DiffcultIndiceMultiplicator;
        [SerializeField] private int DifficultyIndice;

        [Header("Prefabs")]
        public List<GameObject> PlatformPrefabs;
        public List<int> PlatformDifficulty;
        public List<GameObject> PlatformThatCanSpawn;
        Dictionary<GameObject, int> PlatformAndDifficultyDic = new Dictionary<GameObject, int>();
        public List<Transform> PlatformBirthPlace;

        private float _realTime => EndTimeReference.Value - CurrentTimeReference.Value;

        private void Start() {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (gameObject.transform.GetChild(i).CompareTag("Couloir"))
                {
                    PlatformBirthPlace.Add(this.gameObject.transform.GetChild(i));
                }
                //List all transform childs of the pattern
            }
        
            for(int i = 0; i < PlatformPrefabs.Count; i++)
            {
                PlatformAndDifficultyDic.Add(PlatformPrefabs[i], PlatformDifficulty[i]);
                //écrit le dictionnaire de rapport prefab/difficulty
            }
        
            DifficultyIndice = Mathf.RoundToInt(_realTime * DifficultyIndiceMax / EndTimeReference.Value * DiffcultIndiceMultiplicator  + DifficultyIndiceMin);
            //Debug.Log("Difficulty rolled : " + DifficultyIndice);

            foreach (KeyValuePair<GameObject, int> pair in PlatformAndDifficultyDic) 
            {
                if (pair.Value <= DifficultyIndice)
                {
                    PlatformThatCanSpawn.Add(pair.Key);
                    //Use pair.Key to get the key
                    //Use pair.Value for value
                }
            }

            foreach (Transform couloir in PlatformBirthPlace)
            {
                Instantiate(PlatformPrefabs[Random.Range(0, PlatformThatCanSpawn.Count)], couloir);
                //generate a random platform in each child of the pattern
            }
           
        }
    }
}
