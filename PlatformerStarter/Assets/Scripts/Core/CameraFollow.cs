using UnityEngine;

namespace LP.Core
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] Transform target = null;
        [SerializeField] Vector3 cameraOffset = new Vector3(0, 0, -10);

        void LateUpdate()
        {
            if(target == null) return;
            
            transform.position = target.position + cameraOffset;
        }
    }
}
