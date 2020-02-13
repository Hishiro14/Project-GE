using System;
using Architecture.Decouplage.SOReferences;
using UnityEngine;

namespace Production.Plugins.RyanScriptableObjects.SOReferences.GameObjectReference {
    [Serializable]
    public class GameObjectReference : Reference<GameObject, GameObjectVariable> {
        public GameObjectReference(GameObject Value) : base(Value) { }
        public GameObjectReference() { }
    }
}