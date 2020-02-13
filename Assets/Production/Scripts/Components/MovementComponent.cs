using Production.Plugins.RyanScriptableObjects.SOReferences.FloatReference;
using Production.Scripts.Entities;
using UnityEngine;

namespace Production.Scripts.Components
{
    public class MovementComponent : MonoBehaviour
    {
        public FloatReference MovementSpeed;
        
        private IMovement _movement;
        private InputEntity InputEntity;
        private PlayerController PlayerController;

        private void Awake()
        {
            _movement = GetComponent<IMovement>();
            InputEntity = _movement.inputEntity;
            PlayerController = GetComponent<PlayerController>();
        }
        void Update()
        {
            PlayerController.Move(InputEntity.HorizontalInput*MovementSpeed.Value, false, InputEntity.Jump, InputEntity.Dash, InputEntity.LeftStickAxisInput.x, InputEntity.LeftStickAxisInput.y);
        }
        
        
        
    
    }
    public interface IMovement
    {
        InputEntity inputEntity { get; }
        PlayerController playerController { get; }
        Transform playerTransform { get; }
        
    }
}