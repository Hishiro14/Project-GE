using System;
using Architecture.Decouplage.SOReferences;
using UnityEngine;

namespace Production.Plugins.RyanScriptableObjects.SOReferences.RectReference {
    [Serializable]
    public class RectReference : Reference<Rect, RectVariable> {
        public RectReference(Rect Value) : base(Value) { }
        public RectReference() { }
    }
}