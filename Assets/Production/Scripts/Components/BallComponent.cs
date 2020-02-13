using UnityEngine;

namespace Production.Scripts.Components
{
    public class BallComponent : MonoBehaviour
    {
        public Rigidbody2D rigidBody;
        [SerializeField] private float ballLaunchSpeed;

        void Start()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            Vector2 diagonalDirection = UnityEngine.Random.insideUnitCircle;
            diagonalDirection.x = diagonalDirection.x >= 0 ? 1 : -1;
            diagonalDirection.y = diagonalDirection.y >= 0 ? 1 : -1;
            rigidBody.AddForce(diagonalDirection * ballLaunchSpeed, ForceMode2D.Impulse);

        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if(col.gameObject.layer == 9)
            {
                Destroy(this.gameObject);
            }
        }

    }
}
