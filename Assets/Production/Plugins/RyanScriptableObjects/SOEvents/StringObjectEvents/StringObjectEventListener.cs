using System;

namespace Production.Plugins.RyanScriptableObjects.SOEvents.StringObjectEvents {
    public class StringObjectEventListener : BaseGameEventListener<Tuple<string, object>, StringObjectEvent, UnityStringObjectEvent> {}
}