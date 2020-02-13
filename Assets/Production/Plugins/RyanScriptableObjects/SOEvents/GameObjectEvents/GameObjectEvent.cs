using UnityEngine;

namespace Production.Plugins.RyanScriptableObjects.SOEvents.GameObjectEvents {
    [CreateAssetMenu(fileName = "GameObject_OnEvent", menuName = "SOEvent/GameObject")]
    public class GameObjectEvent : BaseGameEvent<GameObject> { }
}