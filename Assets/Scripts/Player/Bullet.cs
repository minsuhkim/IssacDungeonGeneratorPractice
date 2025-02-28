using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Player>().DecreaseHP();
            Destroy(gameObject);
        }
        else if(collision.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
