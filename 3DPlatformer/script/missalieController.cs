using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missalieController : MonoBehaviour
{
    public GameObject mace;
    int yray;
    float span = 1.0f;
    float delta = 0;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("setTime", 1);
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject mace1 = Instantiate(mace);
            if (yray == 0)
            {
                yray = 88;
            }
            else if (yray == 1)
            {
                yray = 90;
            }
            else if (yray == 2)
            {
                yray = 105;
            }
            else
            {
                yray = 107;
            }
            mace1.transform.position = new Vector3(-45, yray, 0);
        }
    }

    void setTime()
    {
        span = Random.Range(3.0f, 5.0f);
        yray = Random.Range(0, 4);

        Invoke("setTime", span);
    }
}
