using Production.Scripts.Components;
using UnityEngine;

namespace Production.Scripts.Platforms
{
    public class PlateformGlissante : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Je glisse !!!! ");
                if (other.gameObject.GetComponent<PlayerController>() != null)
                {
                    //other.gameObject.GetComponent<PlayerController>().m_MovementSmoothing = .3f;
                }
            }
        }
        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Je glisse plus !!!!");
                if (other.gameObject.GetComponent<PlayerController>() != null)
                {
                    //other.gameObject.GetComponent<PlayerController>().m_MovementSmoothing = 0.124f;
                }
            }
        }
    }
}
