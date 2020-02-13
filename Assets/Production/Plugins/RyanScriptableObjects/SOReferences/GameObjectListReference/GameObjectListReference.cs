using System;
using System.Collections.Generic;
using Architecture.Decouplage.SOReferences;
using UnityEngine;

namespace Production.Plugins.RyanScriptableObjects.SOReferences.GameObjectListReference {
    [Serializable]
    public class GameObjectListReference : Reference<List<GameObject>, GameObjectListVariable> {
        public GameObjectListReference(List<GameObject> Value) : base(Value) { }
        public GameObjectListReference() { }
    }
}