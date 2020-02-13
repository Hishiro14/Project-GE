using UnityEngine;

namespace Production.Scripts.Platforms
{
   public class RangeExplossion : MonoBehaviour
   {
      public bool PlayerHere;
      private void OnTriggerEnter2D(Collider2D other)
      {
         if (other.gameObject.CompareTag("Player"))
         {
            PlayerHere = true;
         }
      }
   
   }
}
