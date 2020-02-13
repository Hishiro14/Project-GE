using System;
using Architecture.Decouplage.SOReferences;

namespace Production.Plugins.RyanScriptableObjects.SOReferences.FloatReference {
    [Serializable]
    public class FloatReference : Reference<float, FloatVariable> {
        public FloatReference(float Value) : base(Value) { }
        public FloatReference() { }
    }
}
