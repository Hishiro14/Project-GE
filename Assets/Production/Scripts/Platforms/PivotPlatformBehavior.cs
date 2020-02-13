using UnityEngine;

namespace Production.Scripts.Platforms
{
    public class PivotPlatformBehavior : MonoBehaviour
    {
        [SerializeField] private float _rotationPlatform;
        // Update is called once per frame
        void Update()
        {
            _rotationPlatform = transform.rotation.eulerAngles.z;
            if (_rotationPlatform > 45f && _rotationPlatform < 135f || _rotationPlatform > 225f && _rotationPlatform < 315f)
            {
                this.gameObject.layer = LayerMask.NameToLayer("Wall");
            }

            else if (_rotationPlatform <= 45f || _rotationPlatform >= 135f && _rotationPlatform <= 225f || _rotationPlatform >= 315f && _rotationPlatform < 360f)
            {
                this.gameObject.layer = LayerMask.NameToLayer("Ground");
            }
        }
    }
}
