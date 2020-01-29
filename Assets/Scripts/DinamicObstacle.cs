using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinamicObstacle : MonoBehaviour
{
    public float change = 9;
    public float period = 0.5f;
    public float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.deltaTime + time;
        transform.localPosition = transform.localPosition + (transform.right * change * Time.deltaTime);
        if(time > period)
        {
            change = -change;
            time = 0f;
        }

    }
}
