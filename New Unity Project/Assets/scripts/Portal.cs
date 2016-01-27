using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

    public BoxCollider potal_out;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.Equals("player"))
        {
            collider.gameObject.transform.position = potal_out.transform.position;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        Debug.Log("exit potal");
    }
    // Use this for initialization
    void Start()
    {
        
    }
}
