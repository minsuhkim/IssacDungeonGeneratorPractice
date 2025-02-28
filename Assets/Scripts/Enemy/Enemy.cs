using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Room room;

    public int hp = 2;
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

        LookAt();
    }

    private void LookAt()
    {
        if (dir.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
        else if (dir.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }
    }

    private void Die()
    {
        room.enemyCount--;
        if (room.enemyCount == 0)
        {
            room.OpenDoor();
        }
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
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
            hp -= collision.GetComponentInParent<Player>().attack;
            if (hp <= 0)
            {
                Die();
            }
        }
    }
}
