using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Room room;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            room.enemyCount--;
            if(room.enemyCount == 0)
            {
                room.OpenDoor();
            }
        }
    }
}
