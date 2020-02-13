using Architecture.Decouplage.SOReferences;
using UnityEngine;

namespace Production.Plugins.RyanScriptableObjects.SOReferences.RigibodyReference
{
    [CreateAssetMenu(fileName = "Rigidbody_Variable", menuName = "SOVariable/Rigidbody")]
    public class RigidbodyVariable : Variable<Rigidbody2D> { }
}