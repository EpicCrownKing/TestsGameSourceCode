using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private int timeInRange;

    public SpriteRenderer bar;

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y + 0.2f);
        }

        if(transform.position.y <= 1 && transform.position.y >= -1)
        {
            timeInRange++;
            Debug.Log(timeInRange);
            bar.color = Color.Lerp(Color.white * 0.5f, Color.green * 0.5f, (timeInRange / 300f));
            if(timeInRange >= 300)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<FileManager>().layer++;
                GameObject.FindGameObjectWithTag("GameController").GetComponent<FileManager>().ReturnToComputer();
            }
        }
        else
        {
            timeInRange = 0;
            bar.color = Color.white * 0.5f;
        }

        if (transform.position.y <= -10) GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);
    }
}
