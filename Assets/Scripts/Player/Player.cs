using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;

    public int hp = 3;


    private float h;
    private float v;
    private Vector3 dir;

    public AttackType attackType;
    public int attack;
    public float attackRate;
    [SerializeField]
    private CapsuleCollider2D punchCollider;

    private bool isHurt = false;

    private Animator anim;

    private bool attckKeyDown = false;
    private bool isAttack = false;
    private bool isLive = true;

    private void Start()
    {
        isLive = true;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateInput();
        Move();
        Attack();
        LookAt();
    }

    private void UpdateInput()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        attckKeyDown = Input.GetButtonDown("Fire1");
    }

    private void Move()
    {
        if (isLive && !isAttack)
        {
            dir = new Vector3(h, v, 0);
            transform.position += dir.normalized * speed * Time.deltaTime;
            anim.SetBool("isMove", dir == Vector3.zero ? false : true);
        }        
    }

    private void LookAt()
    {
        if(dir.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }
        else if (dir.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
    }

    private void Attack()
    {
        if (isLive && attckKeyDown && !isAttack)
        {
            switch (attackType)
            {
                case AttackType.Kick:
                    anim.SetTrigger("onKick");
                    break;
                case AttackType.Punch:
                    anim.SetTrigger("onPunch");
                    break;
            }
            

            isAttack = true;
            punchCollider.enabled = true;
            Invoke("ColliderOff", 0.2f * attackRate);
            Invoke("AttackOff", attackRate);
        }
    }

    private void ColliderOff()
    {
        punchCollider.enabled = false;
    }

    private void AttackOff()
    {
        isAttack = false;
        
    }

    public void DecreaseHP()
    {
        if (!isHurt)
        {
            isHurt = true;
            Invoke("EndHurt", 1f);
            hp--;
            if (hp <= 0)
            {
                hp = 0;
                isLive = false;
                GameManager.instance.GameOver();
            }
            else
            {
                anim.SetTrigger("onHurt");
            }
            GameManager.instance.HpUIUpdate();
        }        
    }

    private void EndHurt()
    {
        isHurt = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Room")
        {
            isHurt = true;
            Invoke("EndHurt", 1f);
        }
    }
}
