using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Transform modelTransform;
    public float rotationSmoothSpeed = 5f;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

        if (modelTransform != null)
        {
            Vector3 forward = modelTransform.forward;
            forward.y = 0f;

            Quaternion targetRotation = Quaternion.LookRotation(forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothSpeed * Time.deltaTime);
        }
    }
}
