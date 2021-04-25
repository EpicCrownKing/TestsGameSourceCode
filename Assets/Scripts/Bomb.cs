using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public FruitManager manager;

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            manager.failed = true;

            gameObject.SetActive(false);

            GameObject.FindGameObjectWithTag("SliceSound").GetComponent<AudioSource>().Play();
        }
    }
}
