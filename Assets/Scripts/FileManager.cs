using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FileManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (notepadText == null)
        {
            GameObject notepad = GameObject.FindGameObjectWithTag("Notepadtext");
            if (notepad != null) notepadText = notepad.GetComponent<Text>();
        }

        if (notepadText != null)
        {
            switch (layer)
            {
                case 0:
                    notepadText.text = "Welcome to the MALICE CO terminal (patent pending). To go deeper into the Terminal, please open folder 2. Within folder 2 " +
                        "lay classified tiles, but if you're a MALICE CO employee you should have no issue solving those puzzles. Folders are locked with MALICE CO Tests, " +
                        "which you may have heard of from our television employment advertisements. All Tests can be solved using only a mouse.";
                    break;
                case 1:
                    notepadText.text = "You are now accessing classified files. Opening a wrong folder will kick you out of the Terminal, to keep out " +
                        "those pesky GOOD INC hackers, so take note of what the README files tell you. To proceed, pick the folder that the LAYER text " +
                        "shows. Conditions to continue VARY BY LAYER. LAYER indicates how far in you are in the MALICE CO Terminal. The higher the layer, the deeper in the Terminal's classified files you are. " +
                        "The highest layer is a classified value and you will not know until you reach it. The last layer holds the MALICE CO Server shutoff button. Pressing " +
                        "it will turn off all active MALICE CO computers. Only press IN CASE OF EMERGENCY.";
                    break;
                case 2:
                    notepadText.text = "You are now accessing LAYER 2 files. To proceed, select the number that best represents the fourth letter in MALICE. " +
                        "As an employee of MALICE CO, you must know that MALICE CO was founded in 2003 by Max Haywire, our prestigious CEO. He created MALICE CO as oppositon " +
                        "to the monopoly GOOD INC held over the server hosting business.";
                    break;
                case 3:
                    notepadText.text = "You are now in the DEEP layers of the MALICE CO Terminal. By proceeding DEEPER into the MALICE CO Terminal, you attest that you " +
                        "hold permission to pass this far. To proceed, select the first number you used to enter the Terminal. Max Haywire, our present and glorious leader, " +
                        "runs MALICE CO with the vision of creating servers to allow anyone to host anything - anything.";
                    break;
                case 4:
                    notepadText.text = "As proof of your employment to MALICE CO, please select the file with the number most resembling of our founding year. MALICE CO's " +
                        "servers have been home to an almost infinite number of applications, run by people around the world. We allow anyone to run anything and our security " +
                        "policies do not let us disclose or look at what applications are run on our servers. As a MALICE CO employee, you attest that you know this.";
                    break;
                case 5:
                    notepadText.text = "We said previously we would not disclose the location of the shutoff button, but because you have made it this far we assume your role in MALICE " +
                        "CO. To proceed, state the number of layers you have accessed that are classified, THIS LAYER NOT COUNTED. The proceeding folder contains the MALICE CO shutoff button. " +
                        "This is only to be pressed IN CASE OF EMERGENCY. Proceed with caution. If Mr. Haywire has not personally asked you to proceed, stand down.";
                    break;
            }
        }

        if(layerText != null) layerText.text = "Layer: " + layer;
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            GameObject.FindGameObjectWithTag("File1").GetComponent<Button>().onClick.AddListener(delegate { CheckCorrectFile(1); });
            GameObject.FindGameObjectWithTag("File2").GetComponent<Button>().onClick.AddListener(delegate { CheckCorrectFile(2); });
            GameObject.FindGameObjectWithTag("File3").GetComponent<Button>().onClick.AddListener(delegate { CheckCorrectFile(3); });
            GameObject.FindGameObjectWithTag("File4").GetComponent<Button>().onClick.AddListener(delegate { CheckCorrectFile(4); });

            layerText = GameObject.FindGameObjectWithTag("Layertext").GetComponent<Text>();
            GameObject notepad = GameObject.FindGameObjectWithTag("Notepadtext");
            if (notepad != null) notepadText = notepad.GetComponent<Text>();
        }
    }

    public void ReturnToComputer()
    {
        SceneManager.LoadScene(1);
    }

    private static FileManager fileManager;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (fileManager == null)
        {
            fileManager = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }

    public int layer;

    public Text layerText;
    public Text notepadText;

    public GameObject[] files = new GameObject[4];

    public void CheckCorrectFile (int id)
    {
        Debug.Log(id);
        switch (layer)
        {
            case 0:
                if (id == 2) { layer = 1; SceneManager.LoadScene(1); }
                else layer = 0;
                break;
            case 1:
                Debug.Log("based " + id);
                if (id == 1) SceneManager.LoadScene(2);
                else { layer = 0; SceneManager.LoadScene(1); }
                break;
            case 2:
                if (id == 1) SceneManager.LoadScene(3);
                else { layer = 0; SceneManager.LoadScene(1); }
                break;
            case 3:
                if (id == 2) SceneManager.LoadScene(4);
                else { layer = 0; SceneManager.LoadScene(1); }
                break;
            case 4:
                if (id == 3) SceneManager.LoadScene(5);
                else { layer = 0; SceneManager.LoadScene(1); }
                break;
            case 5:
                if (id == 4) SceneManager.LoadScene(6);
                else { layer = 0; SceneManager.LoadScene(1); }
                break;
        }
    }
}
