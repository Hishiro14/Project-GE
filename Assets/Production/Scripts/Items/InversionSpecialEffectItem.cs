using System.Collections.Generic;
using System.Linq;
using Production.Scripts.Entities;
using UnityEngine;

namespace Production.Scripts.Items
{
    [CreateAssetMenu(fileName = "InversionSpecialEffectItem", menuName = "Items/InversionSpecialEffectItem")]
    public class InversionSpecialEffectItem : SpecialEffectItem
    {
        public List<PlayerEntity> otherPlayers = new List<PlayerEntity>();
        public override void GetList()
        {
            otherPlayers.Clear();
            var otherplayerArray = FindObjectsOfType<PlayerEntity>();
            otherPlayers = otherplayerArray.ToList();
           
        }
        public override void SpecialBonusEffect(Transform player)
        {
            if (otherPlayers.Count > 1)
            {
                otherPlayers.Sort(delegate(PlayerEntity A, PlayerEntity B) { 
                    return Vector3.Distance(A.transform.position, player.position).CompareTo(Vector3.Distance(B.transform.position, player.position));
                });
                var PlayerPosition = player.position;
                player.position = otherPlayers[otherPlayers.Count - 1].transform.position;
                otherPlayers[otherPlayers.Count - 1].transform.position = PlayerPosition; 
            }
            else
            {
                Debug.Log("Not Enough player to invert");
            }
           
        }
    }
}