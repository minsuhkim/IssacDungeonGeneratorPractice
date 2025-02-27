using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;

    public int hp = 3;

    private float h;
    private float v;
    private Vector3 dir;
    [SerializeField]
    private Vector3 attackDir;

    [SerializeField]
    private float fireForce = 10.0f;
    [SerializeField]
    private float attackRate = 0.2f;
    [SerializeField]
    private CapsuleCollider2D punchCollider;
    private Vector3 mousePos;

    private Animator anim;

    private bool fireKeyDown = false;
    private bool isFire = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateInput();
        Move();
        Fire();
        LookAt();
    }

    private void UpdateInput()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        fireKeyDown = Input.GetButton("Fire1");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Move()
    {
        if (!isFire)
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

    private void Fire()
    {
        if (fireKeyDown && !isFire)
        {
            anim.SetTrigger("onAttack");
            attackDir = (mousePos - transform.position);
            attackDir.z = 0;

            isFire = true;
            punchCollider.enabled = true;
            Invoke("FireOff", attackRate);
        }
    }


    private void FireOff()
    {
        isFire = false;
        punchCollider.enabled = false;
    }

    public void DecreaseHP()
    {
        hp--;
    }
}
