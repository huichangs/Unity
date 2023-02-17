using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinDelete : MonoBehaviour
{
    GameObject director;
    // Start is called before the first frame update
    void Start()
    {
        director = GameObject.Find("gameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            director.GetComponent<gameDirector>().addScore();
            Destroy(gameObject);
        }
    }
}
