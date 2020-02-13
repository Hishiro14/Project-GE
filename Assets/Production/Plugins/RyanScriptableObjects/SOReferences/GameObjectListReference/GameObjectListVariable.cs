using System.Collections.Generic;
using UnityEngine;

namespace Production.Plugins.RyanScriptableObjects.SOReferences.GameObjectListReference {

    [CreateAssetMenu(fileName = "GameObjectList_Variable", menuName = "SOVariable/GameObjectList")]
    public class GameObjectListVariable : Variable<List<GameObject>> { }
}