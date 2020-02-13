using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrancheAppartionRate : MonoBehaviour
{
    public int ApparitionChanceRate; // X / 100
    
    void Start()
    {
        int roll = Random.Range(0, 100);
        if (roll >= ApparitionChanceRate)
        {
            this.gameObject.SetActive(false);
        }
    }
}
