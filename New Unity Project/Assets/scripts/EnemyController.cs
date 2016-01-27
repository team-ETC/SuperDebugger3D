using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
    public Vector3 enemyPositionDefault;
    public Vector3 enemyPositionPatrol;
    private string status;
    private string save_status;
    public GameObject enemy;
    public GameObject player;
    private Rigidbody rb;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float patrolWaitTime = 1f;
    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        status = "patrol_p";
        save_status = status;
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.CompareTag("Player")) {
            status = "chase";
        }
        
    }

    void OnTriggerExit(Collider collider) {
        if (collider.gameObject.CompareTag("Player"))
        {
            status = save_status;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement;

        Vector3 enemyPosition = enemy.transform.position;
        Vector3 playerPosition = player.transform.position;/*
        if (Vector3.Distance(enemyPosition, playerPosition) < collider.radius)
        {
            status = "chase";
        }*/
        
        if (status.Equals("patrol_p"))
        {
            movement = (enemyPositionDefault - enemyPosition) / Vector3.Distance(enemyPositionDefault, enemyPosition);
            if (enemyPosition.z >= enemyPositionDefault.z)
            {
                status = "patrol_d";
                save_status = status;
                
            }
            rb.velocity = movement * patrolSpeed;
        }
        else if (status.Equals("patrol_d"))
        {
            movement = (enemyPositionPatrol - enemyPosition) / Vector3.Distance(enemyPositionPatrol, enemyPosition);
            if (enemyPosition.z <= enemyPositionPatrol.z)
            {
                status = "patrol_p";
                save_status = status;
                
            }
            rb.velocity = movement * patrolSpeed;
        }
        else if (status.Equals("chase"))
        {
            movement = (playerPosition - enemyPosition) / Vector3.Distance(playerPosition, enemyPosition);
            rb.velocity = movement * chaseSpeed;

        }
    }
}
