using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnyWheel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spinning)
        {
            GetComponent<Transform>().Rotate(new Vector3(0, 0, spinSpeed));
        }
    }

    public bool spinning;

    public SpinManager manager;

    public float spinSpeed;

    public void StartSpinning()
    {
        spinning = true;
    }

    public void StopSpinning()
    {
        spinning = false;
    }
}
