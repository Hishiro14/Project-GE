using Architecture.Decouplage.SOReferences;
using UnityEngine;

namespace Production.Plugins.RyanScriptableObjects.SOReferences.RectReference {

    [CreateAssetMenu(fileName = "Rect_Variable", menuName = "SOVariable/Rect")]
    public class RectVariable : Variable<Rect> { }
}