using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Agent : MonoBehaviour
{

    float span = 1.0f;
    float delta = 0.0f;


    GameObject character;
    Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("setTime", 1);
        character = GameObject.Find("Character");
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.delta += Time.deltaTime;


        if (this.delta > 1.0f * this.span)
        {
            transform.rotation = Quaternion.Euler(0, 18, 0);
        }
        if(this.delta > this.span * 2.0f)
        {
            transform.rotation = Quaternion.Euler(0, 36, 0);
        }
        if(this.delta > this.span * 3.0f)
        {
            transform.rotation = Quaternion.Euler(0, 54, 0);
        }
        if (this.delta > this.span * 4.0f)
        {
            transform.rotation = Quaternion.Euler(0, 72, 0);        
        }
        if (this.delta > this.span * 5.0f)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (this.delta > this.span * 6.0f)
        {
            transform.rotation = Quaternion.Euler(0, 108, 0);
        }
        if (this.delta > this.span * 7.0f)
        {
            transform.rotation = Quaternion.Euler(0, 126, 0);
        }
        if (this.delta > this.span * 8.0f)
        {
            transform.rotation = Quaternion.Euler(0, 144, 0);
        }
        if (this.delta > this.span * 9.0f)
        {
            transform.rotation = Quaternion.Euler(0, 162, 0);
        }
        if (this.delta > this.span * 10.0f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            delta = -5.0f;
        }
        if (this.delta > 0.0f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (character.GetComponent<CharacterController>().moveDirect != Vector3.zero && character.GetComponent<Rigidbody>().position.z >= 74 && character.GetComponent<Rigidbody>().position.z < 115 && rigid.transform.eulerAngles.y == 180)
        {
            SceneManager.LoadScene("Start");
        }

    }

    void setTime()
    {
        span = Random.Range(0.5f, 1.0f);

        Invoke("setTime", span);
    }
}
