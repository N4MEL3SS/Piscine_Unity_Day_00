using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameObject bird;
    public GameObject pipe0;
    public GameObject pipe1;
    public GameObject pipe2;

    private float rotate;
    private int flag;

    int checkPosition(Vector3 position)
    {
        var positionLeft = position.x - 1.0f;
        var positionRight = position.x + 1.0f;
        
        if (positionLeft < -8.0f && positionRight > -8.0f)
        {
            var positionTop = position.y + 0.5f;
            var positionBottom = position.y - 0.7f;
            var birdTop = bird.transform.position.y + 0.5f;
            var birdBottom = bird.transform.position.y - 0.5f;
            if (positionTop < birdTop || birdBottom < positionBottom)
                return (1);
        }

        return (0);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rotate = 0.0f;
        flag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag >= 1)
        {
            Destroy(bird);
            return;
        }
        if (Input.GetKeyDown("space") && bird.transform.position.y < 1.25f)
        {
            rotate = 45.0f;
            bird.transform.rotation = Quaternion.Euler(0, 0, rotate);
            bird.transform.position += new Vector3(0, 1.1f, 0);
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
    }
}
