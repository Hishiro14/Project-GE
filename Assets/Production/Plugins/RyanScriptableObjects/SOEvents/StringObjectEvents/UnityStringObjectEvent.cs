using System;
using UnityEngine.Events;

namespace Production.Plugins.RyanScriptableObjects.SOEvents.StringObjectEvents {
    [Serializable] public class UnityStringObjectEvent : UnityEvent<Tuple<string, object>> {}
}