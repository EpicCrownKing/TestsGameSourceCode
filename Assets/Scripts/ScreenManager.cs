using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite blackscreen;
    public Sprite errorscreen;
    public Sprite windowsbg;

    public bool hasStarted = false;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = blackscreen;
    }

    /*Ray ray;
    RaycastHit hit;
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {

        }
    }*/

    public GameObject fileexplorer;

    void Update()
    {
        if (hasStarted)
        {
            if (Time.frameCount < 60)
            {
                GetComponent<SpriteRenderer>().sprite = errorscreen;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = windowsbg;

                if (!fileexplorer.active) fileexplorer.SetActive(true);
            }
        }
    }

    public void SetActive()
    {
        hasStarted = true;
    }

    public void OpenFileExplorer()
    {
        SceneManager.LoadScene(1);
    }
}
