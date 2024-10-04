using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;

    public int pointValue;
    private float minSpeed = 12.0f;
    private float maxSpeed = 16f;
    private float minTorque = 10;
    private float xRange = 4;
    private float ySpawnPos  = -2;

    private GameManager gameManager;

    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRB = GetComponent<Rigidbody>();

        throwRandomBoxes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);

        }
        
    }

    private void OnTriggerEnter(Collider other)
    { 
        if(gameObject.CompareTag("Good")) {
            gameManager.GameOver();

            Debug.Log("game over");
        }
        Invoke("DestroyObject", 0.1f);


    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }


    void throwRandomBoxes()
    {
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPosr();



    }

     Vector3 RandomForce()
    {

        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

     float RandomTorque()
    {

        return Random.Range(-minTorque, minTorque);
    }

     Vector3 RandomSpawnPosr()
    {

        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }



}
