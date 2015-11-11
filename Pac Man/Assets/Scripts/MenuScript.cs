using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

    static public int ballNum;
    static public GameObject gameManager;
	
	// Update is called once per frame
	void Update () {
	
	}

    public void quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    public void startLevel(string name)
    {
        Application.LoadLevel(name);
    }
}
