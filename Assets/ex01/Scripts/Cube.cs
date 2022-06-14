using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float fallSpeed;
        
    // Start is called before the first frame update
    void Start()
    {
        fallSpeed = Random.Range(0.005f, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0f, -fallSpeed, 0f);
        if (this.transform.position.y < -7.0f)
            Destroy(this);
    }
}
