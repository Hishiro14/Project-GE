using System;
using UnityEngine;

namespace Production.Plugins.RyanScriptableObjects.SOEvents.StringObjectEvents {
    [CreateAssetMenu(fileName = "StringObjectTuple_OnEvent", menuName = "SOEvent/StringObjectTuple")]
    public class StringObjectEvent : BaseGameEvent<Tuple<string, object>> {}
}
