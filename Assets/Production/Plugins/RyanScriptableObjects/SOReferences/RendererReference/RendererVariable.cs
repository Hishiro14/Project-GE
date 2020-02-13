using Architecture.Decouplage.SOReferences;
using UnityEngine;

namespace Production.Plugins.RyanScriptableObjects.SOReferences.RendererReference {
    [CreateAssetMenu(fileName = "Renderer_Variable", menuName = "SOVariable/Renderer")]
    public class RendererVariable : Variable<Renderer> { }
}