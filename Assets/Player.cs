using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Rigidbody2D rigidBody2d;
    public bool isGrounded = false;

    float direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        direction = Input.GetAxis("Horizontal"); //if pressed right return 1 else if left then -1, if none then  return 0

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidBody2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);//pula
        }
    }

    //Called by Physics
    void FixedUpdate()
    {
        rigidBody2d.velocity = new Vector2(direction * speed, rigidBody2d.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GroundTag"))
        {
            isGrounded = true;
        }else if (collision.gameObject.CompareTag("EndGameTag"))
        {
            print("endGame");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GroundTag"))
        {
            isGrounded = false;
        }
    }


}
