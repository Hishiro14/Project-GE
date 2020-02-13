using System;
using Architecture.Decouplage.SOReferences;
using UnityEngine;

namespace Production.Plugins.RyanScriptableObjects.SOReferences.CameraReference {
    [Serializable]
    public class CameraReference : Reference<Camera, CameraVariable> {
        public CameraReference(Camera Value) : base(Value) { }
        public CameraReference() { }
    }
}