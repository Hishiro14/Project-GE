using UnityEngine;

namespace Production.Plugins.RyanScriptableObjects.SOEvents.VoidEvents {
    [CreateAssetMenu(fileName = "Void_OnEvent", menuName = "SOEvent/Void")]
    public class VoidEvent : BaseGameEvent<Void> {
        
        public void Raise() => Raise(new Void());
        
    }
}