using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Room room;

    public float speed = 2.5f;
    private Transform target;
    private Vector3 dir;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        dir = target.position - transform.position;
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().DecreaseHP();
        }
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
