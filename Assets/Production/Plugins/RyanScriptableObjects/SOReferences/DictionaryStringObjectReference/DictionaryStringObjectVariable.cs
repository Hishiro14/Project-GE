using System.Collections.Generic;
using UnityEngine;

namespace Production.Plugins.RyanScriptableObjects.SOReferences.DictionaryStringObjectReference {
    [CreateAssetMenu(fileName = "DictionaryStringObject_Variable", menuName = "SOVariable/DictionaryStringObject")]
    public class DictionaryStringObjectVariable : Variable<Dictionary<string, object>> { }
}