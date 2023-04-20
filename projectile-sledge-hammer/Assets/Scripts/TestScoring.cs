using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScoring : MonoBehaviour
{
    public Reward score;
    public GameObject hitObject;
    
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        score.AddScore(10);
    }

    void Update()
    {
        
    }
}
