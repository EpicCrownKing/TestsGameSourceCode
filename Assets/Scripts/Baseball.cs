using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baseball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Kinematic)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(20, 4, 0);

            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            GetComponent<AudioSource>().Play();
        }

        if(transform.position.x >= 10)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);

            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

            transform.SetPositionAndRotation(new Vector3(-7, 0, 0), new Quaternion(0, 0, 0, 0));
        }
    }
}
