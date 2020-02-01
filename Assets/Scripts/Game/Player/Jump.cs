using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    BoxCollider2D box;
    Rigidbody2D rigidBody;
    [SerializeField] float jumpForce = 10;
    [SerializeField] float speed = 5;
    float scale;
    // Start is called before the first frame update
    void Start()
    {
        box = this.GetComponent<BoxCollider2D>();
        rigidBody = this.GetComponent<Rigidbody2D>();
        scale = this.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        float y_vel = rigidBody.velocity.y;
        float x_vel= 0;
        bool grounded = isGrounded();
        
        if (rigidBody.velocity.y<=0 && grounded )
        {
            y_vel = jumpForce ;
        }

        float move = Input.GetAxisRaw("Horizontal");
        if (move != 0)
        {
            x_vel = speed * move ;
            this.transform.localScale = new Vector3(scale * move, scale);
        }

        rigidBody.velocity = new Vector2(x_vel, y_vel);
    }

    bool isGrounded()
    {
        Vector3 min = box.bounds.min;
        Vector3 max = box.bounds.max;
        Vector2 leftCorner = new Vector2(min.x+0.1F, min.y - 0.1f);
        Vector2 rightCorner = new Vector2(max.x - 0.1F, min.y - 0.2f);
        Collider2D hit = Physics2D.OverlapArea(leftCorner, rightCorner);
        return hit != null && hit.transform.parent.name!= "Barier" && hit.name != "GameOver";
    }
}
