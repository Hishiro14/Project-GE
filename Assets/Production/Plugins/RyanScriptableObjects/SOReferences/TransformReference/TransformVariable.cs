using Architecture.Decouplage.SOReferences;
using UnityEngine;

namespace Production.Plugins.RyanScriptableObjects.SOReferences.TransformReference {
    [CreateAssetMenu(fileName = "Transform_Variable", menuName = "SOVariable/Transform")]
    public class TransformVariable : Variable<Transform> { }
}