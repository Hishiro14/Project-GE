using System;
using Architecture.Decouplage.SOReferences;

namespace Production.Plugins.RyanScriptableObjects.SOReferences.StringReference {
    [Serializable]
    public class StringReference : Reference<string, StringVariable> {
        public StringReference(string Value) : base(Value) { }
        public StringReference() { }
    }
}