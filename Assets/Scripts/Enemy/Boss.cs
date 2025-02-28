using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Room room;

    public int hp = 10;


    public GameObject bulletPrefab;
    public Transform target;

    private Animator anim;



    private void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(5f);
        Fire();
        yield return new WaitForSeconds(1f);
        Fire();
        yield return new WaitForSeconds(1f);
        Fire();
        StartCoroutine(Attack());
    }

    private void Fire()
    {
        anim.SetTrigger("onAttack");
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce((target.position - transform.position).normalized * 5f, ForceMode2D.Impulse);
    }

    private void Die()
    {
        Destroy(gameObject);
        GameManager.instance.GameClear();
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        collision.gameObject.GetComponent<Player>().DecreaseHP();
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            hp -= GameManager.instance.player.attack;
            GameManager.instance.bossHPSlider.GetComponentInChildren<Slider>().value = hp / (float)10;
            if (hp <= 0)
            {
                Die();
            }
        }
    }

    
}
