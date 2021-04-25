using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    public SpinnyWheel[] wheels = new SpinnyWheel[3];
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            if (wheels[0].spinning)
            {
                if (wheels[0].GetComponent<Transform>().rotation.z <= 1 / 9f && wheels[0].GetComponent<Transform>().rotation.z >= -1 / 9f)
                {
                    wheels[0].StopSpinning();
                    wheels[1].StartSpinning();
                }
                //else Reset();
            }
            else if (wheels[1].spinning)
            {
                Debug.Log(wheels[1].transform.rotation.z);
                if (wheels[1].GetComponent<Transform>().rotation.z <= -0.5f + (1 / 9f) && wheels[1].GetComponent<Transform>().rotation.z >= 0.5f - (1 / 9f))
                {
                    wheels[1].StopSpinning();
                    wheels[2].StartSpinning();
                }
                //else Reset();
            }
            else if (wheels[2].spinning)
            {
                if (wheels[2].GetComponent<Transform>().rotation.z >= (Mathf.PI * 3 / 4) + (1 / 9f) && wheels[2].GetComponent<Transform>().rotation.z >= (Mathf.PI * 3 / 4) - (1 / 9f))
                {
                    //GameObject.FindGameObjectWithTag("GameController").GetComponent<FileManager>().layer++;
                    //GameObject.FindGameObjectWithTag("GameController").GetComponent<FileManager>().ReturnToComputer();

                    wheels[2].StopSpinning();
                }
                //else Reset();
            }
        //}
    }

    public void Reset()
    {
        wheels[0].StartSpinning();
        wheels[0].GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);

        wheels[1].StopSpinning();
        wheels[1].GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);

        wheels[2].StopSpinning();
        wheels[2].GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);
    }
}
