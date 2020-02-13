using System;
using Architecture.Decouplage.SOReferences;
using UnityEngine;

namespace Production.Plugins.RyanScriptableObjects.SOReferences.Texture2DReference {
    [Serializable]
    public class Texture2DReference : Reference<Texture2D, Texture2DVariable> {
        public Texture2DReference(Texture2D Value) : base(Value) { }
        public Texture2DReference() { }
    }
}