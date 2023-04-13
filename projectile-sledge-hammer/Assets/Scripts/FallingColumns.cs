using UnityEngine;

public class FallingColumns : MonoBehaviour
{
    public Transform hitObject;
    public float magnitudeCol, radius, power, upwards;
    [SerializeField] private AudioSource fallingCol;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > magnitudeCol)
        {
            fallingCol.Play();
            // Vector3 returnToHand = hitObject.transform.position;
        }
    }
}
