using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public int movePower = 5;
    int move;
    int thinkTime;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Invoke("think", 2);
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector3(move * movePower, rigid.velocity.y, 0);

        Vector3 front = new Vector3(rigid.position.x + move, rigid.position.y);
        Debug.DrawRay(front, new Vector3(0, -1, 0), new Color(1, 0, 0));
        RaycastHit2D hit = Physics2D.Raycast(front, new Vector3(0, -1, 0), 1);

        if(hit.collider == null)
        {
            move = move * -1;
        }
    }

    void think()
    {
        move = Random.Range(-2, 2);
        thinkTime = Random.Range(1, 3);

        Invoke("think", thinkTime);
    }
}
