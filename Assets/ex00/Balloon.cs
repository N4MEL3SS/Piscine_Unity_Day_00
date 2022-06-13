using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] private GameObject boomSprite;
    [SerializeField] private GameObject balloonSprite;
    [SerializeField] private GameObject breathObject;
    
    private float breath = 1f;
    
    void endGame()
    {
        Debug.Log("Balloon life time: " + Mathf.RoundToInt(Time.time) + "s");
        if (balloonSprite.transform.localScale.x > 5.0f);
            boomSprite.transform.position = new Vector3(0, 1, 0);
        Destroy(balloonSprite);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        boomSprite.transform.position = new Vector3(0, 10, 0);
        balloonSprite.transform.localScale = new Vector3 (1.2f, 1.2f, 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (balloonSprite.transform.localScale.x > 5.0f)
            endGame();
        if (Input.GetKeyDown("space") && breathObject.transform.localScale.x > 0.1f)
        {
            breathObject.transform.localScale -= new Vector3(0.3f, 0, 0);
            balloonSprite.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        }
        else
        {
            if (breathObject.transform.localScale.x < 1.2f)
                breathObject.transform.localScale += new Vector3(0.002f, 0, 0);
            if (balloonSprite.transform.localScale.x > 0.1f)
                balloonSprite.transform.localScale -= new Vector3(0.002f, 0.002f, 0.002f);
            else
                endGame();
        }
        
    }
}
