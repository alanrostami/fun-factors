using UnityEngine;

public class FallingColumns : MonoBehaviour
{
    public GameObject hitObject;
    public float magnitudeCol, radius, power, upwards;
    [SerializeField] private AudioSource fallingCol;

    void Start()
    {
        fallingCol.Stop();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > magnitudeCol)
        {
            fallingCol.Play();
            // Destroy(hitObject);
        }
    }
}
