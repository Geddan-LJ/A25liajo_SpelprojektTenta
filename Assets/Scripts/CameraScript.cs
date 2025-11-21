using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform player;

    void Update()
    {
        Vector3 playerPos = new Vector3(player.position.x, player.position.y, -10f);
        
        transform.position = playerPos;
    }
}
