using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerSlash : MonoBehaviour
{
    public Animator anim;
    public List<Slash> slashes;

    private bool throwing;

    [SerializeField] private AudioSource rotateHammer;

    void Start()
    {
        DisableSlashes();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !throwing)
        {
            throwing = true;
            // anim.SetTrigger("rotate");
            rotateHammer.Play();
            anim.SetBool("ready", true);
            StartCoroutine(SlashThrow());
        }
    }

    IEnumerator SlashThrow()
    {
        for (int i = 0; i < slashes.Count; i++)
        {
            yield return new WaitForSeconds(slashes[i].delay);
            slashes[i].slashObj.SetActive(true);
        }

        yield return new WaitForSeconds(1);
        DisableSlashes();
        throwing = false;
    }

    void DisableSlashes()
    {
        for (int i = 0; i < slashes.Count; i++)
        {
            slashes[i].slashObj.SetActive(false);
        }
    }
}

[System.Serializable]
public class Slash
{
    public GameObject slashObj;
    public float delay;
}