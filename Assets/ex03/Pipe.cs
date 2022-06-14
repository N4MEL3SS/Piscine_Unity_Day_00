using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public GameObject panel0;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject pipe0;
    public GameObject pipe1;
    public GameObject pipe2;
    public GameObject bird;

    private float speed = 0.003f;
    private float sizeA = -0.15f;
    private float sizeB = -2.15f;

    void BackgroundMove(GameObject backGround)
    {
        backGround.transform.position -= new Vector3(speed, 0, 0);
        if (backGround.transform.position.x <= 0.15f)
            backGround.transform.position = new Vector3(13.0f, -2.5f, 0);
    }
    
    void PipeMove(GameObject pipe)
    {
        pipe.transform.position -= new Vector3(speed, 0, 0);
        if (pipe.transform.position.x <= -11.0f)
            pipe.transform.position = new Vector3(1.0f, Random.Range(sizeA, sizeB), 0);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        pipe0.transform.position = new Vector3(-1, Random.Range(sizeA, sizeB), 0);
        pipe1.transform.position = new Vector3(3, Random.Range(sizeA, sizeB), 0);
        pipe2.transform.position = new Vector3(7, Random.Range(sizeA, sizeB), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (bird == null)
        {
            speed = 0;
            return;
        }
        BackgroundMove(panel0);
        BackgroundMove(panel1);
        BackgroundMove(panel2);
        
        PipeMove(pipe0);
        PipeMove(pipe1);
        PipeMove(pipe2);
    }
}
