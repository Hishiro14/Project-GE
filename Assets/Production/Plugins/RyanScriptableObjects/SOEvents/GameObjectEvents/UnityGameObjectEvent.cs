using System;
using UnityEngine;
using UnityEngine.Events;

namespace Production.Plugins.RyanScriptableObjects.SOEvents.GameObjectEvents {
    [Serializable] public class UnityGameObjectEvent : UnityEvent<GameObject> {}
}