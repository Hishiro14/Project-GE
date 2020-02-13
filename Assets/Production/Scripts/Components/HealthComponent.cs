using Production.Plugins.RyanScriptableObjects.SOEvents.GameObjectEvents;
using Production.Plugins.RyanScriptableObjects.SOReferences.BoolReference;
using UnityEngine;

namespace Production.Scripts.Components
{

    public class HealthComponent : MonoBehaviour
    {
        public GameObjectEvent playerDead;
        private IHealth _health;
        public float CurrentHP;
        private ScoreComponent scoreComponent;

        public float BumpForce=500;

        public BoolReference ShieldActive;
        public GameObject ShieldGO;

        //sound 
        public SoundComponent sound;

        void Awake()
        {
            sound = GetComponent<SoundComponent>();
            _health = GetComponent<IHealth>();
            ShieldActive.Value = false;
            CurrentHP = _health.MaxHP;
            scoreComponent = GetComponent<ScoreComponent>();
        }

        private void Update()
        {
            if (ShieldActive.Value)
            {
                ShieldGO.SetActive(true);
            }

            if (ShieldActive.Value == false)
            {
                ShieldGO.SetActive(false);
            }
        }

        void OnGetDamage(int damage){

            if (ShieldActive.Value == false)
            {
               scoreComponent.incrementTimer=0f;
                CurrentHP -= (float)damage;
                sound.Play("HurtFx");
                if(CurrentHP <= 0){
                    playerDead.Raise(this.gameObject);
                    CurrentHP = _health.MaxHP;
                }
            }
            
        }
        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.layer == 9){
                scoreComponent.incrementTimer=0f;
                playerDead.Raise(this.gameObject);
                sound.Play("HurtFx");
                CurrentHP = _health.MaxHP;
            }
            if (col.gameObject.CompareTag("Ball")){
                
                OnGetDamage(3);
                Debug.Log("Balled");
                sound.Play("ShieldBreak");
                ShieldActive.Value = false;
            }
            if (col.gameObject.CompareTag("Spike")){

                OnGetDamage(3);
               
            }
            //se repousser sur collision
            if (col.gameObject.CompareTag("Player"))
            {
                var otherPlayerRb = col.gameObject.GetComponent<Rigidbody2D>();
                float velocity = this.GetComponent<Rigidbody2D>().velocity.magnitude;
                float otherVelocity = otherPlayerRb.velocity.magnitude;
                if (velocity > otherVelocity)
                {
                    velocity = Mathf.Clamp(velocity, 0f, 5f);
                    Vector2 bumpDirection = otherPlayerRb.position - this.GetComponent<Rigidbody2D>().position;
                    bumpDirection.Normalize();
                    otherPlayerRb.AddForce(bumpDirection*velocity*BumpForce, ForceMode2D.Impulse);
                }
               
            }
        }
      
    }

    interface IHealth
    {
        float MaxHP { get; }
    }
}