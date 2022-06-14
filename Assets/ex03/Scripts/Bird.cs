using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameObject bird;
    public GameObject pipe0;
    public GameObject pipe1;
    public GameObject pipe2;

    private float rotate;
    private int flag;
    private int player_score;
    private bool flag_pipe0;
    private bool flag_pipe1;
    private bool flag_pipe2;

    int checkPosition(Vector3 position)
    {
        var positionLeft = position.x - 1.0f;
        var positionRight = position.x + 1.0f;
        
        if (positionLeft < -8.0f && positionRight > -8.0f)
        {
            var positionTop = position.y + 1.0f;
            var positionBottom = position.y - 1.0f;
            var birdTop = bird.transform.position.y + 0.2f;
            var birdBottom = bird.transform.position.y - 0.2f;
            if (positionTop < birdTop || birdBottom < positionBottom)
                return (1);
        }

        return (0);
    }

    bool score(Vector3 position, bool checkFlag)
    {
        if (!checkFlag && bird.transform.position.x > position.x)
        {
            player_score += 5;
            return (true);
        }
        else if (bird.transform.position.x < position.x)
        {
            return (false);
        }
        return (true);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rotate = 0.0f;
        flag = 0;
        player_score = 0;
        flag_pipe0 = false;
        flag_pipe1 = false;
        flag_pipe2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag >= 1)
        {
            Debug.Log("Score:" + player_score);
            Debug.Log("Time: " + Mathf.RoundToInt(Time.time) + "s");
            Destroy(bird);
            return;
        }
        if (Input.GetKeyDown("space") && bird.transform.position.y < 1.25f)
        {
            rotate = 45.0f;
            bird.transform.rotation = Quaternion.Euler(0, 0, rotate);
            bird.transform.position += new Vector3(0, 0.9f, 0);
            if (bird.transform.position.y > 1.25f)
                bird.transform.position = new Vector3(-8.0f, 1.2f, 0);
        }
        else if (bird.transform.position.y > -3.6f)
        {
            rotate -= 0.15f;
            bird.transform.position -= new Vector3(0, 0.004f, 0);
            bird.transform.rotation = Quaternion.Euler(0, 0, rotate);
        }

        flag += checkPosition(pipe0.transform.position);
        flag += checkPosition(pipe1.transform.position);
        flag += checkPosition(pipe2.transform.position);
        flag_pipe0 = score(pipe0.transform.position, flag_pipe0);
        flag_pipe1 = score(pipe1.transform.position, flag_pipe1);
        flag_pipe2 = score(pipe2.transform.position, flag_pipe2);
    }
}
