using System;
using Architecture.Decouplage.SOReferences;

namespace Production.Plugins.RyanScriptableObjects.SOReferences.IntReference {
    [Serializable]
    public class IntReference : Reference<int, IntVariable> {
        public IntReference(int Value) : base(Value) { }
        public IntReference() { }
    }
}