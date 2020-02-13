using UnityEngine;

namespace Production.Scripts.Platforms
{
    public class ExplosivePlaform : MonoBehaviour
    {
        public float timer;
        public float timerAfterDetection;
        private bool IsActive;
        private bool timerdestroypalyer;
        public GameObject ExplosionRangeCollision;
        public GameObject PlaneColor;
        public Material blue;
        public Material black;

        private void Start()
        {
            ExplosionRangeCollision.SetActive(false);
        }

        void Update()
        {
            if (IsActive) timer -= Time.deltaTime;


            if (timer <= 0)
            {
                timerdestroypalyer = true;
                ExplosionRangeCollision.SetActive(true);
                //PlaneColor.GetComponent<MeshRenderer>().material = blue;
            }

            if (timerdestroypalyer) timerAfterDetection -= Time.deltaTime;

            if (timerAfterDetection <= 0)
            {
                Destroy(gameObject);
            }
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            IsActive = true;
            //PlaneColor.GetComponent<MeshRenderer>().material = black;
        }
    }
}
