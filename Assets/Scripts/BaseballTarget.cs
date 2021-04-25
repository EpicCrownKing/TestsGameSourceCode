using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, Mathf.Sin((Time.frameCount / 25f) + (Mathf.PI / 2f)) / 30f, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Baseball")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<FileManager>().layer++;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<FileManager>().ReturnToComputer();
        }
    }
}
