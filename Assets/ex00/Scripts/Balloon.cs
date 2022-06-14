using UnityEngine;
using UnityEngine.SceneManagement;

public class Balloon : MonoBehaviour
{
    public GameObject boomSprite;
    public GameObject balloonSprite;
    public GameObject staminaSprite;
    
    void gameQuit()
    {
        Application.Quit();
    }
    
    void endGameBoom()
    {
        Debug.Log("Balloon life time: " + Mathf.RoundToInt(Time.time) + "s");
        boomSprite.transform.position = new Vector3(0, 1, 0);
        Destroy(balloonSprite);
        gameQuit();
    }
    
    void gameEnd()
    {
        Debug.Log("Balloon life time: " + Mathf.RoundToInt(Time.time) + "s");
        Destroy(balloonSprite);
        gameQuit();
        
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
        if (Mathf.RoundToInt(Time.time) > 15.0f)
            gameEnd();
        if (Input.GetKeyDown("escape"))
            gameQuit();
        if (Input.GetKeyDown("space") && staminaSprite.transform.localScale.x > 0.3f)
        {
            staminaSprite.transform.localScale -= new Vector3(0.3f, 0, 0);
            balloonSprite.transform.localScale += new Vector3(0.5f, 0.5f, 0);
        }
        else
        {
            if (staminaSprite.transform.localScale.x < 1.2f)
                staminaSprite.transform.localScale += new Vector3(0.001f, 0, 0);
            if (balloonSprite.transform.localScale.x > 0.1f)
                balloonSprite.transform.localScale -= new Vector3(0.001f, 0.001f, 0);
            else
                gameEnd();
        }
        
    }
}
