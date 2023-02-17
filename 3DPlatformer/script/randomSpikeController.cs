using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomSpikeController : MonoBehaviour
{
    public GameObject spikeDown;
    float span = 0.2f;
    float delta = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject spike = Instantiate(spikeDown);
            float px = Random.Range(-9.0f, 17.0f);
            spike.transform.position = new Vector3(px, 53, 0);
        }

    }


}
