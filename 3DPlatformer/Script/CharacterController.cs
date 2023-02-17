using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    float hAxis;
    float vAxis;
    bool rDown;
    bool jump;
    public Vector3 moveDirect;
    Animator anime;

    Rigidbody rigid;
    bool isJump;

    GameObject director;


    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
        director = GameObject.Find("gameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        Restart();
        GetInput();
        Move();
        Jump();


    }



    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        rDown = Input.GetButton("Run");
        jump = Input.GetButton("Jump");
    }

    void Move()
    {
        moveDirect = new Vector3(hAxis, 0, vAxis).normalized;

        if (rDown)
        {
            transform.position += moveDirect * speed * Time.deltaTime * 2;
        }
        else
        {
            transform.position += moveDirect * speed * Time.deltaTime;
        }

        transform.LookAt(transform.position + moveDirect);
        anime.SetBool("isWalk", moveDirect != Vector3.zero);
        anime.SetBool("isRun", rDown);
    }

    void Jump()
    {
        if (jump && !isJump)
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJump = true;
            anime.SetBool("isJump", true);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            anime.SetBool("isJump", false);
            isJump = false;
        }

        if (collision.gameObject.tag == "enemy")
        {          
            rigid.AddForce(new Vector3(0, 5f, -10f), ForceMode.Impulse);
            director.GetComponent<GameDirector>().decreaseScore();
        }

        if (collision.gameObject.tag == "hurdle")
        {
            rigid.AddForce(new Vector3(0, 5f, -10f), ForceMode.Impulse);
            director.GetComponent<GameDirector>().decreaseScore();
        }
    }

    void Restart()
    {
        if (rigid.position.y < -10)
        {
            SceneManager.LoadScene("Start");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Start");
        }
    }

}
