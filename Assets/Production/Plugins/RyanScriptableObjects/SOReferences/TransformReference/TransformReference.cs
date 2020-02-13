using System;
using Architecture.Decouplage.SOReferences;
using UnityEngine;

namespace Production.Plugins.RyanScriptableObjects.SOReferences.TransformReference {
    [Serializable]
    public class TransformReference : Reference<Transform, TransformVariable> {
        public TransformReference(Transform Value) : base(Value) { }
        public TransformReference() { }
    }

}
