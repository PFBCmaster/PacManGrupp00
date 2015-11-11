using UnityEngine;
using System.Collections;



    public class PointsScript : SpawnScript
    {

        int pointsCount;
        public int lives;
        public int maxPoints;

        //Metod som man kallar på när PacMan kolliderar med ett object som ger poäng.
        public void Points(int points)
        {
            pointsCount += points;

            if (pointsCount >= maxPoints)
            {
                //pointsScrean
                //låsupp nästa bana
            }

            if (pointsCount > 100)
            {
                lives++;
            }
        }

        //Metod som man kallar på när PacMan kolliderar med ett object som dödar PacMan.
        public void Damage()
        {
            lives--;
        kill = true;
            //pacManSpawn(new Vector3(41, 7, 428));
        GetComponent<Rigidbody>().position =new Vector3(41, 7, 428);

        if (lives <= 0)
            {
                // pointsScrean
            }
        }

        //Visar stats.
        void OnGUI()
        {
            GUI.Label(new Rect(10, 10, 100, 20), "Points: " + pointsCount.ToString());
            GUI.Label(new Rect(10, 20, 100, 20), "Lives: " + lives.ToString());
        }

    }

