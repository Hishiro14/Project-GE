using System.Collections.Generic;
using Production.Plugins.RyanScriptableObjects.SOReferences.BoolReference;
using UnityEngine;

namespace Production.Scripts.Items
{
    [CreateAssetMenu(fileName = "DurationItem", menuName = "Items/DurationItem")]
    public class DurationBoolItem : Item
    {
        public List<BoolReference> ActivateBoolBonus = new List<BoolReference>();
        
        public float _durationItemTimer;
        public float Duration;
        public override void Activate(BoolReference activateBoolBonus)
        {
            if(ActivateBoolBonus.Count>0) activateBoolBonus.Value = true;
            
        }
        public override void Unactive(BoolReference activateBoolBonus)
        {
            activateBoolBonus.Value = false;
            
        }
    }
}