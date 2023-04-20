using UnityEngine;

public class FallingColumns : MonoBehaviour
{
    public GameObject hitObject;
    public float magnitudeCol, radius, power, upwards;
    [SerializeField] private AudioSource fallingCol;

    // public Reward score;

    void Start()
    {
        fallingCol.Stop();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > magnitudeCol)
        {
            fallingCol.Play();
            Reward.score += 10;
        }
    }
}
