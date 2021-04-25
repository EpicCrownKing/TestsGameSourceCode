using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject[] gores = new GameObject[2];

    public FruitManager manager;

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            GameObject gore1 = Instantiate(gores[0], gameObject.transform.position, gameObject.transform.rotation, null);
            GameObject gore2 = Instantiate(gores[1], gameObject.transform.position, gameObject.transform.rotation, null);

            gore1.transform.Rotate(0, 0, Random.Range(0f, 360f));
            gore2.transform.Rotate(0, 0, Random.Range(0f, 360f));

            gore1.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
            gore2.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);

            manager.fruitsSliced++;

            gameObject.SetActive(false);

            GameObject.FindGameObjectWithTag("SliceSound").GetComponent<AudioSource>().Play();
        }
    }
}
