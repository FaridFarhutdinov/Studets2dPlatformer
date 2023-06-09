using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;

    Vector2 startingPosition;

    float startZ;

    Vector2 travel => (Vector2)cam.transform.position - startingPosition;

    float distanceFromTarget  => transform.position.z - followTarget.position.z;

    float clippingPlane => (cam.transform.position.z + (distanceFromTarget > 0? cam.farClipPlane : cam.nearClipPlane));

    float parallaxFactor => Mathf.Abs(distanceFromTarget) / clippingPlane;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = startingPosition + (travel * parallaxFactor);

        transform.position = new Vector3(newPosition.x, newPosition.y, startZ);
    }
}
