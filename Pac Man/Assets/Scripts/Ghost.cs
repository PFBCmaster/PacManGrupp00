using UnityEngine;
using System.Collections;


public class Ghost : MonoBehaviour {

    private GameObject pacMan;
    private NavMeshAgent ghost;
    private float wanderRange = 100.0f;
    private Vector3 startPosition; 
    private bool roaming = true;  
    private bool attacking = false;
    void Start () {

        startPosition = this.transform.position;
        ghost = GetComponent<NavMeshAgent>();
        pacMan = GameObject.Find("PacMan(Clone)");
        InvokeRepeating("Roaming", 1f, 5f);
        //Vector3 position = new Vector3(Random.Range(-40f, 140f), 0, Random.Range(-180, 440));
        //ghost.SetDestination(randomPos);
        //ghost.updatePosition = false;

    }
	
    void Roaming() //Metod för agenternas vandringsläge. Skapar en instans som tar en agents startkordinat och lägger till en slumpmässig kordinat,
                   //detta resultat används sedan som argument när NewDestination() metoden kallas.
    {
        Vector3 destination = startPosition + new Vector3(Random.Range(-wanderRange, wanderRange), 0, Random.Range(-wanderRange, wanderRange));
        NewDestination(destination);
    }

    public void NewDestination(Vector3 nyPos) // Sänder agenten till en punkt i kordinatsystemet.
    {
        ghost.SetDestination(nyPos);
    }

    void Attack()
    {
        ghost.SetDestination(pacMan.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

        /* FreeRoam();

         if (ghost.transform.position = 10)

     }

    
     void FreeRoam()
     {

             Vector3 randomDirection = Random.insideUnitCircle * 100;
             randomDirection += transform.position;
             NavMeshHit hit;
             NavMesh.SamplePosition(randomDirection, out hit, Random.Range(-100f, 100f), 1);
             Vector3 finalPosition = hit.position;
             ghost.destination = finalPosition;

     }

    
     */

    }
}
