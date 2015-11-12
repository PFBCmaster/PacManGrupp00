using UnityEngine;
using System.Collections;


public class Ghost : MonoBehaviour {

    private Transform target;
    private GameObject pacMan;
    private NavMeshAgent ghost;
    private float wanderRange = 200.0f;
    private Vector3 startPosition; 
    private bool roaming = false;  
    private bool attacking = false;
    private float distanceToAttack = 100.0f;
    public float roamingDelayTimer;

    void Start () {

        startPosition = this.transform.position;
        ghost = GetComponent<NavMeshAgent>();
        pacMan = GameObject.Find("PacMan(Clone)");
        //InvokeRepeating("Roaming", 1f, 5f);
        

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

    void startRoaming()
    {
        
        roamingDelayTimer -= Time.deltaTime;
        if (roamingDelayTimer <= 0 && !attacking)
        {
            Roaming();
            roamingDelayTimer = 5.0f;
        }
    }

  
    void Attack()
    {
        ghost.SetDestination(pacMan.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

        //startRoaming();
        float distFromPac = Vector3.Distance(ghost.transform.position, pacMan.transform.position);


        if (distFromPac <= distanceToAttack)
        {
            Attack();
        }

        if (distFromPac > distanceToAttack)
        {
            startRoaming();
        }

        

    }
}
