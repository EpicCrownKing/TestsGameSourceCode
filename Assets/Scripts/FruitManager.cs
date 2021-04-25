using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool failed;

    public int fruitsSliced;

    public GameObject bomb;

    void Update()
    {
        if(Time.frameCount % 60 == 0)
        {
            GameObject newFruit = Instantiate(fruits[Random.Range(0, fruits.Length)], new Vector3(Random.Range(-5f, 5f), -8, 0), new Quaternion(0, 0, Random.Range(0f, 360f), 0), null);
            
            newFruit.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-5f, 5f), 15, 0);
            newFruit.transform.Rotate(0, 0, Random.Range(0f, 360f));

            newFruit.GetComponent<Fruit>().manager = GetComponent<FruitManager>();
        }
        if(Time.frameCount % 190 == 0)
        {
            GameObject newBomb = Instantiate(bomb, new Vector3(Random.Range(-5f, 5f), -8, 0), new Quaternion(0, 0, Random.Range(0f, 360f), 0), null);

            newBomb.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-5f, 5f), 15, 0);
            newBomb.transform.Rotate(0, 0, Random.Range(0f, 360f));

            newBomb.GetComponent<Bomb>().manager = GetComponent<FruitManager>();
        }

        if(failed)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<FileManager>().ReturnToComputer();
        }

        if(fruitsSliced > 10)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<FileManager>().layer++;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<FileManager>().ReturnToComputer();
        }
    }

    public GameObject[] fruits = new GameObject[2];
}
