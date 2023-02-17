using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
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

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "character")
        {
            director.GetComponent<GameDirector>().addStageScore();
            director.GetComponent<GameDirector>().addFlag();
            Destroy(gameObject);
        }
    }
}
