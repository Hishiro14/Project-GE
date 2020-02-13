using System.Collections.Generic;
using Production.Plugins.RyanScriptableObjects.SOReferences.BoolReference;
using Production.Plugins.RyanScriptableObjects.SOReferences.FloatReference;
using UnityEngine;

namespace Production.Scripts
{
    [CreateAssetMenu(fileName = "InstantItem", menuName = "Items/InstantItem")]
    public class InstantFloatItem : Item
    {
        public List<FloatReference> ActivateFloatBonus = new List<FloatReference>();
        public float FloatBonus;
        
        public override void Activate(BoolReference activateBoolBonus)
        {
            //
        }
        public virtual void ActivateFloat(int reference)
        {
           if(ActivateFloatBonus.Count>0) ActivateFloatBonus[reference].Variable.Value += FloatBonus;
        }

        
    }
}