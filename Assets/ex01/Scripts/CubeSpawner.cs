using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cube;
    public KeyCode key;
    public float positionX;
    
    private GameObject note;

    void InitClone()
    {
        GameObject.Destroy(note);
        note = GameObject.Instantiate(cube, new Vector3(positionX, 6.0f, 0), Quaternion.identity);
    }

    void getLog()
    {
        var logPrecision = (4.0f + note.transform.position.y) * 100.0f;
        if (logPrecision >= 0)
            Debug.Log("Precision: " + (100.0f - logPrecision));
        else
            Debug.Log("Precision: " + ((logPrecision + 100.0f) * -1.0f));
    }
    
    // Use this for initialization
    void Start ()
    {
        note = GameObject.Instantiate(cube, new Vector3(positionX, 6.0f, 0), Quaternion.identity);
    }
	
    // Update is called once per frame
    void Update ()
    {
        // note.transform.Translate(0f, Random.Range(0.05f, 0.01f), 0f);
        if (Input.GetKeyDown(key) && note.transform.position.y is < -3.0f and > -5.0f)
        {
            getLog();
            note.transform.position = new Vector3(positionX, 6.0f, 0);
        }

        if (note.transform.position.y < -6.0f)
            note.transform.position = new Vector3(positionX, 6.0f, 0);
    }
}
