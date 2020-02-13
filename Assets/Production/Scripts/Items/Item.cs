using System;
using Production.Plugins.RyanScriptableObjects.SOReferences.BoolReference;
using UnityEngine;

namespace Production.Scripts
{
    [Serializable]
    public abstract class Item : ScriptableObject
    {
        public string Description;
        public Sprite ItemIcon;
        
        public abstract void Activate(BoolReference activateBoolBonus);
        public virtual void Unactive(BoolReference activateBoolBonus)
        {
            
        }

    }
}