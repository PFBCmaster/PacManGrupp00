using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

    public GameObject pacMan;
    public GameObject ball;
    public GameObject map;
    public GameObject fruit;
    public GameObject pill;
    public GameObject ghostP;
    public GameObject ghostK;
    public GameObject ghostI;
    public GameObject ghostB;
    public bool kill;
    Vector3[] pillVector;
    Vector3[] ghostVector = new Vector3[4];
    Vector3[] ballPosition = new Vector3[2];

    void Start ()
    {
        //Vectorer för spöken på test bana 
        ghostVector[0] = new Vector3 (12,-17,301);
        ghostVector[1] = new Vector3 (35,-17, 300);
        ghostVector[2] = new Vector3 (61,-17,279);
        ghostVector[3] = new Vector3 (67,-17,301);

        ballPosition[0] = new Vector3(35, 11, 400);
        ballPosition[1] = new Vector3(35, 11, 410);

        spawnMap(map.transform.position, ballPosition, 2);

        spawnInky(ghostVector[0]);
        spawnPinky(ghostVector[1]);
        spawnKlyde(ghostVector[2]);
        spawnBlinky(ghostVector[3]);
        kill = false;
    }

    //Spawnar PacMan
    public void pacManSpawn(Vector3 pacManVector)
    {
        Instantiate(pacMan, pacManVector, Quaternion.identity);
 
    }

    //Startar en ny bana med bollar och en PacMan.
    void spawnMap(Vector3 mapPosition, Vector3[] ballPosition, int ballNumber)
    {
        Instantiate(map, mapPosition, Quaternion.identity);
        pacManSpawn(new Vector3(35, 9, 440));
        for (int i = 0; i < ballNumber; i++)
        {
            Instantiate(ball, ballPosition[i], Quaternion.identity);
        }
        
    }

    //Spawnar frukt
    void spawnfruit(Vector3 fruitVector)
    {
        Instantiate(fruit, fruitVector, Quaternion.identity);
    }

    //Spawnar piller
    void spawnPill(Vector3 pillVector)
    {
        Instantiate(pill, pillVector, Quaternion.identity);
    }

    //Spawnar ett spöke
    void spawnInky(Vector3 ghostVector)
    {
        Instantiate(ghostI, ghostVector, Quaternion.identity);
    }
    void spawnPinky(Vector3 ghostVector)
    {
        Instantiate(ghostP, ghostVector, Quaternion.identity);
    }
    void spawnBlinky(Vector3 ghostVector)
    {
        Instantiate(ghostB, ghostVector, Quaternion.identity);
    }
    void spawnKlyde(Vector3 ghostVector)
    {
        Instantiate(ghostK, ghostVector, Quaternion.identity);
    }


    void Update()
    {
        if (kill == true)
        {
            pacManSpawn(new Vector3(35, 9, 440));
            kill = false;
        }
    }

}
