using UnityEngine;

namespace Production.Scripts.Platforms
{
    public class BallInstantiator : MonoBehaviour
    {
        public float timer;
        public GameObject BallPrefab;
    
        // Start is called before the first frame update
        void Start()
        {
            Invoke("CreateBall", timer);
        }

        void CreateBall()
        {
            Instantiate(BallPrefab, transform);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
