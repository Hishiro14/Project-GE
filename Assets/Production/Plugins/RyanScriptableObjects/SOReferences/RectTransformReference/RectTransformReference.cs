using System;
using Architecture.Decouplage.SOReferences;
using UnityEngine;

namespace Production.Plugins.RyanScriptableObjects.SOReferences.RectTransformReference {
    [Serializable]
    public class RectTransformReference : Reference<RectTransform, RectTransformVariable> {
        public RectTransformReference(RectTransform Value) : base(Value) { }
        public RectTransformReference() { }
    }
}