using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class characterController : MonoBehaviour
{
    public float movePower = 10f;     
    public float jumpPower = 20f; //Set Gravity Scale in Rigidbody2D Component to 5

    Rigidbody2D rigid;
    Animator anim;
    Vector3 movement;
    int direction = 1;
    bool isJumping = false;
    bool alive = true;
    GameObject director;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        director = GameObject.Find("gameDirector");
    }

    private void Update()
    {
        Restart();
        if (alive)
        {
            Die();
            Jump();
            Run();

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        anim.SetBool("isJump", false);
    
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            director.GetComponent<gameDirector>().decreaseHp();
            anim.SetTrigger("hurt");
            if (direction == 1)
                rigid.AddForce(new Vector2(-10f, 5f), ForceMode2D.Impulse);
            else
                rigid.AddForce(new Vector2(10f, 5f), ForceMode2D.Impulse);
        }

        if(collision.gameObject.tag == "coin")
        {
            director.GetComponent<gameDirector>().increaseHp();
        }

        if(collision.gameObject.tag == "chest")
        {
            anim.SetBool("isJump", false);
            anim.SetBool("isRun", false);
            alive = false;

        }
    }

    void Run()
    {
            
        Vector3 moveVelocity = Vector3.zero;
        anim.SetBool("isRun", false);


        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            direction = -1;
            moveVelocity = Vector3.left;
                    
            transform.localScale = new Vector3(direction, 1, 1);
                    
            if (!anim.GetBool("isJump"))
            {
                anim.SetBool("isRun", true);

            }
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
            {
            direction = 1;
            moveVelocity = Vector3.right;

            transform.localScale = new Vector3(direction, 1, 1);

            if (!anim.GetBool("isJump"))
            {
                anim.SetBool("isRun", true);
            }

        }

            transform.position += moveVelocity * movePower * Time.deltaTime;      
    }

    void Jump()
    {
        if ((Input.GetAxisRaw("Vertical") > 0) && !anim.GetBool("isJump"))
        {
            isJumping = true;
            anim.SetBool("isJump", true);
        }

        if (!isJumping)
        {
            return;
        }

        rigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumpPower);
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);

        isJumping = false;
    }

    void Die()
    {
        if (director.GetComponent<gameDirector>().isDie())
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            anim.SetTrigger("die");
            alive = false;
        }
    }

    void Restart()
    {
        if(rigid.position.y < -10)
        {
            SceneManager.LoadScene("startScene");
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("startScene");
        }
    }
}

