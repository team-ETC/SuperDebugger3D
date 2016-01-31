using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
    private bool reloaded;
    private GameObject bullet;
    private Vector3 loadPos;
    private int reloadFrameCount;
    private int count;
    
	// Use this for initialization
	void Start () {
        reloaded = false;
        loadPos = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
        reloadFrameCount = 100;
        count = reloadFrameCount;
        bullet = null;
    }

    void LateUpdate()
    {
        if (!reloaded)
        {
            count--;
        }
    }

    void OnTriggerStay(Collider collider)
    {
        Debug.Log(count);
        
        if (reloaded)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                if (Input.GetKey(KeyCode.K))
                {
                    bullet.rigidbody.velocity = new Vector3(5, 5, 5);
                    bullet = null;
                    reloaded = false;
                    count = reloadFrameCount;
                }
            }
        }
        else
        {
            if (count <= 0)
            {
                if (collider.gameObject.CompareTag("Item"))
                {
                    bullet = collider.gameObject;
                    bullet.transform.position = loadPos;
                    reloaded = true;
                }
            }
            
        }
    }
}
