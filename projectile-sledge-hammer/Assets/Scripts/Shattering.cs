using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shattering : MonoBehaviour
{
    public float cubeSize = 1f;
    public int cubesInRow = 5;

    float cubesPivotDistance;
    Vector3 cubesPivot;

    public float shatterForce = 50f;
    public float shatterRadius = 4f;
    public float shatterUpward = 0.4f;

    void Start()
    {
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Shatter();
    }

    public void Shatter()
    {
        gameObject.SetActive(false);

        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    CreatePiece(x, y, z);
                }
            }
        }

        Vector3 shatterPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(shatterPos, shatterRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(shatterForce, transform.position, shatterRadius, shatterUpward);
            }
        }
    }

    void CreatePiece(int x, int y, int z)
    {
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
    }
}
