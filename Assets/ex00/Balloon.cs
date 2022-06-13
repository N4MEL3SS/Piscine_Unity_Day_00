using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] private GameObject boomSprite;
    [SerializeField] private GameObject balloonSprite;
    [SerializeField] private GameObject breathObject;
    
    private float startTime = Time.time;
    
    void endGameBoom()
    {
        Debug.Log("Balloon life time: " + Mathf.RoundToInt(Time.time) + "s");
        boomSprite.transform.position = new Vector3(0, 1, 0);
        Destroy(balloonSprite);
    }
    
    void endGame()
    {
        Debug.Log("Balloon life time: " + Mathf.RoundToInt(Time.time) + "s");
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
            endGameBoom();
        if (Time.time - startTime > 15.0f)
            endGame();
        if (Input.GetKeyDown("space") && breathObject.transform.localScale.x > 0.1f)
        {
            breathObject.transform.localScale -= new Vector3(0.3f, 0, 0);
            balloonSprite.transform.localScale += new Vector3(0.45f, 0.45f, 0.45f);
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
