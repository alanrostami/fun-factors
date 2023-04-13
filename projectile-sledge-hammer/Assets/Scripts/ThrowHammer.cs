using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowHammer : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    [Header("Animation")]
    public Animator anim;

    bool readyToThrow;
    [SerializeField] private AudioSource rotateHammer;
    [SerializeField] private AudioSource throwHammer;
    
    private void Start()
    {
        readyToThrow = true;
    }

    private void Update()
    {
        if (Input.GetKeyUp(throwKey) && readyToThrow && totalThrows > 0)
        {
            anim.SetBool("ready", false);
            rotateHammer.Stop();
            Throw();
        }
    }

    private void Throw()
    {
        readyToThrow = false;
        throwHammer.Play();

        // Instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        // Get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // Calculate direction
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        // Add force
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        // Implement throwCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
        // objectToThrow.transform.position = new Vector3(52.13f, 4.47f, -49.02f);
    }
}
