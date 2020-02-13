using System;
using Architecture.Decouplage.SOReferences;
using UnityEngine;

namespace Production.Plugins.RyanScriptableObjects.SOReferences.RigibodyReference
{
    [Serializable]
    public class RigidbodyReference : Reference<Rigidbody2D, RigidbodyVariable>
    {
        public RigidbodyReference(Rigidbody2D Value) : base(Value) {}
        public RigidbodyReference() {}
    }
}