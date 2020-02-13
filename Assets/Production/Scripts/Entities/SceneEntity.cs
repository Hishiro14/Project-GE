using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Production.Scripts.Entities {
    public class SceneEntity : MonoBehaviour {

        public string StartingSceneName;
    
        private void Start() {
            LoadScene(StartingSceneName);
        }

        public void UnloadScene(string scene) {
            if (!UnityEngine.SceneManagement.SceneManager.GetSceneByName(scene).isLoaded) return;
            Debug.Log("Unloading " + scene + "...");
            StartCoroutine(UnloadSceneAsync(scene));
        }
		
        public void LoadScene(string scene) {
            if (UnityEngine.SceneManagement.SceneManager.GetSceneByName(scene).isLoaded) return;
            Debug.Log("Loading " + scene + "...");
            StartCoroutine(LoadSceneAsync(scene));
        }

        public void ReloadScene(string scene) {
            Debug.Log("Reloading " + scene + "...");
            StartCoroutine(ReloadSceneAsync(scene));
        }

        public void ExitGame() {
            Application.Quit();
        }

        public IEnumerator ReloadSceneAsync(string scene) {
            yield return UnloadSceneAsync(scene);
            yield return LoadSceneAsync(scene);
        }
		
        private IEnumerator UnloadSceneAsync(string scene) {
            AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(scene);
            //Wait until the last operation fully loads to return anything
            while (!asyncLoad.isDone) {
                yield return null;
            }
            Debug.Log(scene + " unloaded !");
        }

        private IEnumerator LoadSceneAsync(string scene) {
            AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            //Wait until the last operation fully loads to return anything
            while (!asyncLoad.isDone) {
                yield return null;
            }
            Debug.Log(scene + " loaded !");
        }

    }
}
