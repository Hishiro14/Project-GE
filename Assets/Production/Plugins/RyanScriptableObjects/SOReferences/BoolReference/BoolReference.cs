using System;
using Architecture.Decouplage.SOReferences;

namespace Production.Plugins.RyanScriptableObjects.SOReferences.BoolReference
{
    [Serializable]
    public class BoolReference : Reference<bool, BoolVariable> {
        public BoolReference(bool Value) : base(Value) { }
        public BoolReference() { }
    }
}