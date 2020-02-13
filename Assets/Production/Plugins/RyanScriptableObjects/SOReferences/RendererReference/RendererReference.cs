using System;
using Architecture.Decouplage.SOReferences;
using UnityEngine;

namespace Production.Plugins.RyanScriptableObjects.SOReferences.RendererReference {
    [Serializable]
    public class RendererReference : Reference<Renderer, RendererVariable> {
        public RendererReference(Renderer Value) : base(Value) { }
        public RendererReference() { }
    }

}
