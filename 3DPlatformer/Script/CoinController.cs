using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    GameObject director;
    public float rotateSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        director = GameObject.Find("gameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * rotateSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "character")
        {
            director.GetComponent<GameDirector>().addScore();
            director.GetComponent<GameDirector>().addCoin();
            Destroy(gameObject);
        }
    }
}
