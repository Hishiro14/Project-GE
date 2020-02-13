using System;
using UnityEngine;

namespace Production.Scripts.Platforms
{
    public class CrakeblePlateform : MonoBehaviour
    {
        public int PlateformHp = 4;
        public GameObject childCube;
        public AudioClip crackingSound;
        public AudioClip destroySound;
        private bool IsBeingSteppedOn;



        /*private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Touche");
        childCube.GetComponent<MeshRenderer>().material.color = Color.red;
        PlateformHp--;
        if (PlateformHp == 0)
        {
            Destroy(this.gameObject);
        }
    }*/

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!IsBeingSteppedOn)
            {
                PlateformHp--;
                Debug.Log("Touché ! HP = " + PlateformHp);

                if (crackingSound != null)
                {
                    AudioSource.PlayClipAtPoint(crackingSound, transform.position);
                }


                if (PlateformHp == 1)
                {
                    //childCube.GetComponent<MeshRenderer>().material.color = Color.red;
                    //Change material parameter for fissure
                }
                if (PlateformHp == 0)
                {
                    if (destroySound != null)
                    {
                        AudioSource.PlayClipAtPoint(destroySound, transform.position);
                    }
                    Destroy(this.gameObject);
                }
            }
            IsBeingSteppedOn = true;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            IsBeingSteppedOn = false;
        }
    }
    
    
    
}
