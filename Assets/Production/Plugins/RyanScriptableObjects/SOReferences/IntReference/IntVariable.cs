using Architecture.Decouplage.SOReferences;
using Production.Plugins;
using UnityEngine;

namespace Production{
    [CreateAssetMenu(fileName = "Int_Variable", menuName = "SOVariable/Int")]
    public class IntVariable : Variable<int> {}
}