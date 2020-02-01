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
    // Start is called before the first frame update
    void Start()
    {
        box = this.GetComponent<BoxCollider2D>();
        rigidBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool grounded = isGrounded();
        if (grounded)
        {
            rigidBody.velocity= new Vector2(rigidBody.velocity.x,jumpForce);
        }
    }

    bool isGrounded()
    {
        Vector3 min = box.bounds.min;
        Vector3 max = box.bounds.max;
        Vector2 leftCorner = new Vector2(min.x, min.y - 0.1f);
        Vector2 rightCorner = new Vector2(max.x, min.y - 0.2f);
        Collider2D hit = Physics2D.OverlapArea(leftCorner, rightCorner);
        return hit != null;
    }
}
