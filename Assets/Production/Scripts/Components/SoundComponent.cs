using UnityEngine;
using System;
using Production.Scripts.Framework;
using UnityEngine.Audio;

public class SoundComponent : MonoBehaviour
{
   public Sounds[] _sounds;

   void Awake()
   {
      foreach(Sounds s in _sounds)
      {
         s.source = gameObject.AddComponent<AudioSource>();
         s.source.playOnAwake = false;
         s.source.clip = s.clip;

         s.source.volume = s.Volume;
         s.source.pitch = s.pitch;
      }
   }

   public void Play(string name)
   {
      Sounds s = Array.Find(_sounds, Sounds => Sounds.name == name);
      if(s == null) return;
      s.source.Play();
   }
   
}
