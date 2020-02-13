using UnityEngine;

namespace Production.Scripts.Platforms
{
    public class RangeForceExplossion : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(other);
            }
        }
    }
}
