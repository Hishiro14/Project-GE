using Production.Plugins;
using UnityEngine;

namespace Production.Plugins.RyanScriptableObjects.SOReferences
{
    [CreateAssetMenu(fileName = "Bool_Variable", menuName = "SOVariable/Bool")]
    public class BoolVariable : Variable<bool> {}
}