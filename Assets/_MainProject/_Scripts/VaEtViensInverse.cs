using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaEtViensInverse : MonoBehaviour
{
    private float min = 0f;
    private float max = 50f;

    // Start is called before the first frame update
    void Start()
    {
        min = transform.position.x - 50f;
        max = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float pingPongValue = Mathf.PingPong(Time.time * 30, max - min) + min;
        float newXPos = (2f * max) - pingPongValue;
        transform.position = new Vector3(newXPos, transform.position.y, transform.position.z);
    }
}
