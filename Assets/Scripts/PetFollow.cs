using UnityEngine;

public class PetFollow : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 3f;
    public float followDistance = 2f;

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }

        Vector3 desiredPosition = player.position - player.forward * followDistance;
        desiredPosition.y = player.position.y;

        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, followSpeed * Time.deltaTime);
    }
}
