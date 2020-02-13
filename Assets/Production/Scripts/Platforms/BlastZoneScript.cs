using System;
using System.Collections;
using System.Collections.Generic;
using Production.Scripts.Platforms;
using UnityEngine;

namespace Production.Scripts.Platforms
{
    public class BlastZoneScript : MonoBehaviour
    {
        public PlatformCreation PlatformCreation;

        private void OnTriggerEnter2D(Collider2D other)
        {
            PlatformCreation.DestroyPlatforms(other.gameObject);
        }
    }
}
