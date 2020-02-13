using UnityEngine;

namespace Production.Scripts.Platforms
{
    public class ExplosionScript : MonoBehaviour
    {
        void OnTriggerStay2D(Collider2D other){
            if (other.gameObject.transform.parent.CompareTag("Player"))
            {
                Debug.Log("Kill the player, erase this line when it works");
                //Destroy(other.gameObject.transform.parent.gameObject);
            }
        

        }
    }
}
