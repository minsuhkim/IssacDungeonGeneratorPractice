using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;

    float h;
    float v;
    Vector3 dir;
    private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        dir = new Vector3(h, v, 0);
        transform.position += dir * speed * Time.deltaTime;
    }
}
