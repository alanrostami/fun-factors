using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddon : MonoBehaviour
{
    public int damage;
    private Rigidbody rb;

    private bool targetHit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Only to stick to the first target
        if (targetHit)
            return;
        else
            targetHit = true;
        
        // Check if hit the target
        if (collision.gameObject.GetComponent<TargetDamage>() != null)
        {
            TargetDamage targetdmg = collision.gameObject.GetComponent<TargetDamage>();

            targetdmg.TakeDamage(damage);

            Destroy(gameObject);
        }
        
        transform.SetParent(collision.transform);
    }
}
