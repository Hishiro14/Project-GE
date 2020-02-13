using System.Collections.Generic;
using Production.Plugins.RyanScriptableObjects.SOReferences.BoolReference;
using Production.Plugins.RyanScriptableObjects.SOReferences.FloatReference;
using Production.Plugins.RyanScriptableObjects.SOReferences.GameObjectListReference;
using Production.Plugins.RyanScriptableObjects.SOReferences.GameObjectReference;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Production.Scripts.Platforms {
    public class PlatformCreation : MonoBehaviour {

        [Header("Internal References")]
        public List<GameObject> CurrentPlatforms = new List<GameObject>();
        
        [Header("SO References")] 
        public FloatReference CurrentTimeReference; //Recupère depuis un SO le temps actuel
        public FloatReference EndTimeReference; //Recupère depuis un SO le temps actuel
        public BoolReference IsScrolling;

        [Header("Parameters")]
        public float SpeedBase;
        public float SpawnRateMultiplicator;
        public int PlateformMinNumber; //Minimum de plateformes qui peuvent spawn sur une ligne
        public int PlateformMaxNumber; //Maximum de plateformes qui peuvent spawn sur une ligne
        public float ScrollingSpeed; //vitesse à laquelle il tombe, s'actualise dans Update

        [Header("Prefabs")]
        public List<GameObject> PatternPrefabs4PF4L;
        public List<GameObject> PatternPrefabs3PF4L;
        public List<GameObject> PatternPrefabs2PF4L;
        public List<GameObject> PatternPrefabs1PF4L;
        public List<GameObject> PatternPrefabs3PF3L;
        public List<GameObject> PatternPrefabs2PF3L;
        public List<GameObject> PatternPrefabs1PF3L;
        public GameObject StartFieldPrefab;

        private int _plateformCurrentSpeed;
        private int _nbOfPlatformsToSpawn;
        private GameObject _newPattern;
        private bool _use4Lines;
        
        private float _timeSinceLastSpawn = 3;
        private float _spawnRate; // nb de secondes au bout du quel les plateformes sont instanciées
        private int _plateformNumberOffset;
        private float _plateformDifficulty;

        private float _realTime => EndTimeReference.Value - CurrentTimeReference.Value;

        private void Start()
        {
            _use4Lines = true;
            //Invoke("ScrollStartField", 3f);
        }

        private void ScrollStartField()
        {
            CurrentPlatforms.Add(StartFieldPrefab);
        }

        private void Update() {
            if(!IsScrolling.Value) return;
            //Produit en croix : speed = (temps actuel * max speed possible / fin du temps * un multiplicateur de sécurité ) + strict minimum possible 

            _spawnRate =  SpeedBase / ScrollingSpeed * SpawnRateMultiplicator;
            //pareil mais avec le spawn rate
        
            _plateformNumberOffset = Mathf.RoundToInt((PlateformMaxNumber - PlateformMinNumber) / EndTimeReference.Value * (EndTimeReference.Value - _realTime) + PlateformMinNumber);
            
            //Scroll des plateformes
            foreach (GameObject platform in CurrentPlatforms) {
                platform.transform.position -= transform.up * ScrollingSpeed;
            }
    
            //Instantiation des plateformes
            _timeSinceLastSpawn += Time.deltaTime;
            if (_timeSinceLastSpawn >= _spawnRate) {
                InstantiatePlateform();
                _timeSinceLastSpawn = 0;
            }
        }
    
        private void InstantiatePlateform() {

            _nbOfPlatformsToSpawn = Mathf.Clamp(Random.Range(-3, 3) + _plateformNumberOffset, PlateformMinNumber, PlateformMaxNumber);
            //détermine le nb de plateformes à faire spawn, clamp entre 1 et 4
            //tweeck les valeurs du random range pour augmenter ou diminuer la difficulté du jeu, + ou - de plateformes qui spawn a la fin

            if (_use4Lines)
            {
                switch (_nbOfPlatformsToSpawn) {
                    case 4:
                        _newPattern = Instantiate(PatternPrefabs4PF4L[Random.Range(0, PatternPrefabs4PF4L.Count)], transform);
                        break;
            
                    case 3:                
                        _newPattern = Instantiate(PatternPrefabs3PF4L[Random.Range(0, PatternPrefabs3PF4L.Count)], transform);
                        break; 
            
                    case 2:
                        _newPattern = Instantiate(PatternPrefabs2PF4L[Random.Range(0, PatternPrefabs2PF4L.Count)], transform);
                        break;
            
                    case 1 :
                        _newPattern = Instantiate(PatternPrefabs1PF4L[Random.Range(0, PatternPrefabs1PF4L.Count)], transform);
                        break;
            
                    default: 
                        Debug.Log("wrong nbOfPlatformToSpawn, plz debug baka");
                        break;
                }

                _use4Lines = false;
            }
            else 
            {
                switch (_nbOfPlatformsToSpawn) {
           
                    case 3:                
                        _newPattern = Instantiate(PatternPrefabs3PF3L[Random.Range(0, PatternPrefabs3PF3L.Count)], transform);
                        break; 
            
                    case 2:
                        _newPattern = Instantiate(PatternPrefabs2PF3L[Random.Range(0, PatternPrefabs2PF3L.Count)], transform);
                        break;
            
                    case 1 :
                        _newPattern = Instantiate(PatternPrefabs1PF3L[Random.Range(0, PatternPrefabs1PF3L.Count)], transform);
                        break;
            
                    default: 
                        _newPattern = Instantiate(PatternPrefabs3PF3L[Random.Range(0, PatternPrefabs3PF3L.Count)], transform);
                        break; 
                }
                _use4Lines = true;
            }
            CurrentPlatforms.Add(_newPattern); //ajoute la ligne à la liste pour qu'elle puisse descendre
        }

        public void DestroyPlatforms(GameObject other) {

            if (CurrentPlatforms.Contains(other.gameObject)) {
                CurrentPlatforms.Remove(other.gameObject);
                Destroy(other.gameObject);
            }
        }
    }
}
