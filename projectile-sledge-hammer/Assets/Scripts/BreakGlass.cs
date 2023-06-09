using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakGlass : MonoBehaviour
{
    public Transform brokenObject;
    public float magnitudeCol, radius, power, upwards;
    [SerializeField] private AudioSource breakingGlass;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > magnitudeCol)
        {
            breakingGlass.Play();
            Destroy(gameObject);
            Instantiate(brokenObject, transform.position, transform.rotation);
            brokenObject.localScale = transform.localScale;
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

            foreach (Collider hit in colliders)
            {
                if (hit.attachedRigidbody)
                {
                    hit.attachedRigidbody.AddExplosionForce(power * collision.relativeVelocity.magnitude, explosionPos, radius, upwards);
                }
            }
        }
    }
}
