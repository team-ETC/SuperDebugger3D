using UnityEngine;
using System.Collections;

public class transparentControl : MonoBehaviour {

    // Use this for initialization

    private Color original;
    private float distance;

    void Start()
    {
        original = renderer.material.color;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            renderer.material.SetColor("_Color", renderer.material.GetColor("_Color") - new Color(0, 0, 0, 0f));
        }

    }

    void OnTriggerStay(Collider collider) {
        
        if (collider.gameObject.CompareTag("Player"))
        {
            Ray z_ray = new Ray();
            z_ray.origin = new Vector3(-50, collider.gameObject.transform.position.y, transform.position.z + 1);
            z_ray.direction = new Vector3(1, 0, 0);
            distance = (Vector3.Cross(z_ray.direction, collider.gameObject.transform.position - z_ray.origin).magnitude - collider.gameObject.transform.localScale.z/2f)/10f;
            renderer.material.color = new Color(original.r, original.g, original.b, 0.5f + distance);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            renderer.material.color = original;
        }
    }
}
