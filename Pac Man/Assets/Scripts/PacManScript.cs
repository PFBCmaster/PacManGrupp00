using UnityEngine;
using System.Collections;

public class PacManScript : PointsScript {

    float speed = 20f;
    bool eat;
    float timer;
   

    void OnCollisionEnter(Collision other)
    {
        //PackMan kolliderar med en ball
        if (other.gameObject.tag == "Ball")
        {
            Destroy(other.gameObject);
            Points(1);
        }

        //PackMan kolliderar med en frukt
        if (other.gameObject.tag == "Fruit")
        {
            Destroy(other.gameObject);
            Points(10);
        }

        //PackMan kolliderar med ett piller
        if (other.gameObject.tag == "Weapon")
        {
            Destroy(other.gameObject);
            eat = true;
        }

        //PackMan kolliderar med ett spöke 
        if (other.gameObject.tag == "Ghost")
        {
            if (eat == false)
            {
                Damage();
            }
            else
            {
                Destroy(other.gameObject);
                Points(30);
            }

        }

        //PackMan kolliderar med en teleport
        if (other.gameObject.name == "Teleport1")
        {
            transform.position = new Vector3(160,9,285);
        }
        if (other.gameObject.name == "Teleport2")
        {
            transform.position = new Vector3(-100, 9, 285);
        }


    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            //GetComponent<Rigidbody>().AddForce(Vector3.forward * speed);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.RotateAround(GetComponent<Rigidbody>().position, Vector3.down, 90);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.RotateAround(GetComponent<Rigidbody>().position, Vector3.up, 90);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.RotateAround(GetComponent<Rigidbody>().position, Vector3.up, 180);
        }

    }
        void Update()
    {
        //Om PacMan har tagit upp ett piller ska han istället för att bli dödad av spöken äta dem under en viss tid.
        if (eat == true)
        {
            timer += Time.deltaTime;

            if (timer >= 10)
            {
                eat = false;
                timer = 0;
            }
        }

        Move();

    }

}
