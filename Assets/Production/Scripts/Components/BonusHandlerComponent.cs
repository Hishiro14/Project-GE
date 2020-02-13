using System.Collections.Generic;
using Production.Plugins.RyanScriptableObjects.SOEvents.GameObjectEvents;
using Production.Scripts.Entities;
using Production.Scripts.Items;
using UnityEngine;

namespace Production.Scripts.Components
{
    public class BonusHandlerComponent : MonoBehaviour
    {
        
        public int PlayerID; //player 1 = 0, player 2 = 1, player 3 =2, player 4 = 3
        public List<DurationBoolItem> AvalaibleDurationItem = new List<DurationBoolItem>();
        public List<UntilDeathBoolItem> AvalaibleUntilDeathItem = new List<UntilDeathBoolItem>();
        [SerializeField] private PlayerEntity _playerEntity;

        [SerializeField] private GameObjectEvent OnBonusChange;

        public int BonusCount;

        //Sound
		public SoundComponent sound;

        private void Awake()
        {
            _playerEntity = GetComponent<PlayerEntity>();
            sound = GetComponent<SoundComponent>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("DurationBoolItem"))
            {
                var bonus = other.GetComponent<OnItem>().durationBoolItem;
                if (AvalaibleDurationItem.Find(item => item.name == bonus.name) == false)
                {
                    AvalaibleDurationItem.Add(bonus);
                    OnBonusChange.Raise(gameObject);
                    sound.Play("ItemFx");
                    //BonusImages[BonusCount - 1].sprite = bonus.ItemIcon;
                }
                else
                {
                    var ExistingBonus = AvalaibleDurationItem.Find(item => item.name == bonus.name);
                    ExistingBonus._durationItemTimer = 0;
                    sound.Play("ItemFx");
                }
                if (bonus.ActivateBoolBonus[PlayerID].Value == false)
                {
                    bonus._durationItemTimer = 0;
                    bonus.Activate(bonus.ActivateBoolBonus[PlayerID]);
                    sound.Play("ItemFx");
                }
                Destroy(other.gameObject);
            }
            if (other.CompareTag("UntilDeathBoolItem"))
            {
                var bonus = other.GetComponent<OnItem>().untilDeathBool;
                if (AvalaibleUntilDeathItem.Find(item => item.name == bonus.name)==false)
                {
                    AvalaibleUntilDeathItem.Add(bonus);
                    OnBonusChange.Raise(gameObject);
                    sound.Play("ItemFx");
                    //BonusImages[BonusCount - 1].sprite = bonus.ItemIcon;

                }
                bonus.Activate(bonus.ActivateBoolBonus[PlayerID]);
                Destroy(other.gameObject);
            }

            if (other.CompareTag("SpecialEffectItem"))
            {
                var bonus = other.GetComponent<OnItem>().specialEffectItem;
                bonus.GetList();
                bonus.SpecialBonusEffect(this.transform);
                sound.Play("Inversion");
                Destroy(other.gameObject);
            }

            if (other.CompareTag("InstantItem"))
            {
                var bonus = other.GetComponent<OnItem>().instantFloatItem;
                bonus.ActivateFloat(PlayerID);
                sound.Play("Points");
                Destroy(other.gameObject);
            }
        }

        public void DesactiveAllOnDeath()
        {
            foreach (var durItem in AvalaibleDurationItem)
            {
                durItem.Unactive(durItem.ActivateBoolBonus[PlayerID]);
            }
            foreach (var unDeItem in AvalaibleUntilDeathItem)
            {
                unDeItem.Unactive(unDeItem.ActivateBoolBonus[PlayerID]);
            }
            AvalaibleDurationItem.Clear();
            AvalaibleUntilDeathItem.Clear();
            OnBonusChange.Raise(gameObject);
        }
        private void Update()
        {
            if (AvalaibleDurationItem.Count > 0)
            {
                foreach (var item in AvalaibleDurationItem)
                {
                    if (item != null)
                    {
                        item._durationItemTimer += Time.deltaTime;
                        if (item._durationItemTimer >= item.Duration)
                        {
                            OnBonusChange.Raise(gameObject);
                            item.Unactive(item.ActivateBoolBonus[PlayerID]);
                            AvalaibleDurationItem.Remove(item);
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                
                }
            }

            if (AvalaibleUntilDeathItem.Count > 0)
            {
                
            }
           
        }
    }

}