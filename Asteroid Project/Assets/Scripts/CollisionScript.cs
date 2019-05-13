using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    [SerializeField] Mesh[] asteroidModels;
    //This represents the selection of models we have to use for our asteroids

    [SerializeField] GameObject brokenAsteroidPrefab;

    [SerializeField] int maxSpawns;
    [SerializeField] int minSpawns;
    //These variables are our min and max number of spawns when currently existing asteroids are destroyed

    //Asteroid damage variable
    [SerializeField] int asteroidDamage;


    private void Start()
    {
        //Change mesh to random from asteroid model array
        int modelIndex = Random.Range(0, asteroidModels.Length);
        //modelIndex retrieves a number from our range

        GetComponent<MeshFilter>().mesh = asteroidModels[modelIndex];
        //Then the mesh is changed to the model number selected
    }


    private void OnCollisionEnter(Collision other)
    {
        

        //Check if other is projectile or player
        if (other.gameObject.tag == ("Spaceship")||other.gameObject.tag == ("Projectile"))
        {
            Debug.Log("Hit Detected");
            //Play particles
            //need to add particle effects to the game

            //Generate random number to spawn
            int asteroidsToSpawn = Random.Range(minSpawns, maxSpawns);
            Debug.Log(asteroidsToSpawn);

            float force = Random.Range(1, 3);

            //Loop through asteroids to spawn count
            for (int i = 0; i < asteroidsToSpawn; i++)
            {
                Vector3 originalPosition = other.transform.position;
                //Spawn smaller asteriods
                GameObject newAsteroid = Instantiate(brokenAsteroidPrefab, originalPosition, Quaternion.identity);

                //Add force to smaller asteroids
                Rigidbody rb = newAsteroid.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(force, transform.position, 5);
                }
            }

            //If other is player deal damage

            //Destroy this asteroid
            Destroy(other.gameObject);
        }
    }
}