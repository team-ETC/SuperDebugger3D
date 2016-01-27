using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour {
    public GameObject camera;
    private Transform camTransform;
    Vector3 vector, original;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.Equals("player")) {
            camTransform.Rotate(0, 180, 0);
            camTransform.TransformPoint(vector);
        }
        
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name.Equals("player")) {
            camTransform.Rotate(0, 180, 0);
            camTransform.TransformPoint(original);
        }
    }
    // Use this for initialization
    void Start () {
        
        camTransform = camera.transform;
        original = camTransform.position;
        vector = new Vector3(original.x, original.y, original.z*-1);
    }

    // Update is called once per frame
    //void Update () { }
}
