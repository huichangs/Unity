using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissalieGenerater : MonoBehaviour
{
    public GameObject missalie;
    int xray;
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
            GameObject missalie1 = Instantiate(missalie);
            missalie1.transform.position = new Vector3(xray, 1.5f, 61f);
        }

    }

    void setTime()
    {
        span = Random.Range(2.0f, 3.0f);
        xray = Random.Range(-17, 17);

        Invoke("setTime", span);
    }
}
