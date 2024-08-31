using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minForce = 12.0f;
    private float maxForce = 16.0f;
    private float maxTorqe = 10.0f;
    private float spawnRange = 4.0f;
    private float ySpawnPos = -3;

    public ParticleSystem explosionParticle;
    [SerializeField] int pointValue;
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        AddUpForce();
        AddTorqueToTarget();
        SpawnPosition();

    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(explosionParticle,transform.position,explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
        Destroy(gameObject);
    }

    void AddUpForce()
    {
        targetRb.AddForce(Vector3.up * Random.Range(minForce, maxForce), ForceMode.Impulse);

    }
    void AddTorqueToTarget()
    {
        targetRb.AddTorque(Random.Range(-maxTorqe, maxTorqe), Random.Range(-maxTorqe, maxTorqe), Random.Range(-maxTorqe, maxTorqe), ForceMode.Impulse);
    }
    void SpawnPosition()
    {
        transform.position = new Vector3(Random.Range(-spawnRange, spawnRange), ySpawnPos);

    }




}
