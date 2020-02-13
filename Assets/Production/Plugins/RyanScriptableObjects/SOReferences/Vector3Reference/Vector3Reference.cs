using System;
using Architecture.Decouplage.SOReferences;
using UnityEngine;

namespace Production.Plugins.RyanScriptableObjects.SOReferences.Vector3Reference {
    [Serializable]
    public class Vector3Reference : Reference<Vector3, Vector3Variable> {
        public Vector3Reference(Vector3 Value) : base(Value) { }
        public Vector3Reference() { }
    }
}