using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    public SpinnyWheel[] wheels = new SpinnyWheel[3];
    public AudioSource FailSound;
    public AudioSource Beep2;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (wheels[0].spinning)
            {
                if (wheels[0].GetComponent<Transform>().rotation.z <= 1 / 9f && wheels[0].GetComponent<Transform>().rotation.z >= -1 / 9f)
                {
                    wheels[0].StopSpinning();
                    wheels[1].StartSpinning();

                    GetComponent<AudioSource>().Play();
                }
                else
                {
                    Reset();
                    FailSound.Play();
                }
            }
            else if (wheels[1].spinning)
            {
                if (wheels[1].GetComponent<Transform>().rotation.z <= 1 / 9f && wheels[1].GetComponent<Transform>().rotation.z >= -1 / 9f)
                {
                    wheels[1].StopSpinning();
                    wheels[2].StartSpinning();

                    Beep2.Play();
                }
                else
                {
                    Reset();
                    FailSound.Play();
                }
            }
            else if (wheels[2].spinning)
            {
                if (wheels[2].GetComponent<Transform>().rotation.z <= 1 / 9f && wheels[2].GetComponent<Transform>().rotation.z >= -1 / 9f)
                {
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<FileManager>().layer++;
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<FileManager>().ReturnToComputer();

                    wheels[2].StopSpinning();
                }
                else
                {
                    Reset();
                    FailSound.Play();
                }
            }
        }
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
