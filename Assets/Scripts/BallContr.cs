using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallContr : MonoBehaviour
{
    #region VARIABLES
    GameObject focalPoint;
    public Rigidbody playerRb;
    public float speed = 5.0f;
    public bool hasPowerup;
    float powerUpStrength = 15.0f;
    private float powerUpTime = 5.0f;
    public GameObject spawnManagerBall;
    public GameObject powerupIndicator;
    public Vector3 Offset = Vector3.zero;
    public bool isAlive = true;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("Focal Point");
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        powerupIndicator.transform.position = transform.position + Offset;

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
            spawnManagerBall.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(powerUpTime);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            Debug.Log("Collided with:" + collision.gameObject.name + "with powerup set to" + hasPowerup);
        }
    }
}
