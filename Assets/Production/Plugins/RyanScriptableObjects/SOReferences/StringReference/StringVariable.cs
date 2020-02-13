using Architecture.Decouplage.SOReferences;
using UnityEngine;

namespace Production.Plugins.RyanScriptableObjects.SOReferences.StringReference {

    [CreateAssetMenu(fileName = "String_Variable", menuName = "SOVariable/String")]
    public class StringVariable : Variable<string> { }
}