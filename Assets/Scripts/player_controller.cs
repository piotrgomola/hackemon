using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    
    private float vertical;
    private float horizontal;
    

    public float speed = 10.0f;
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 = LEFT ... 1 -> RIGHT
        vertical = Input.GetAxisRaw("Vertical");  // -1 = DOWN ... 1 -> DOWN

        if (horizontal != 0.0f || vertical != 0.0f) {
            playerAnimator.SetBool("moveDown", true);
        } else {
            playerAnimator.SetBool("moveDown", false);
        }

        if (horizontal < 0.0f) {
            spriteRenderer.flipX = true;
        } else if (horizontal > 0.0f) {
            spriteRenderer.flipX = false;
        }
    }

    void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    
}
