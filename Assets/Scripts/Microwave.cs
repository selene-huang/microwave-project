using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microwave : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
 
    }

    public void Explode()
    {
        animator.SetTrigger("Explode");
        animator.SetTrigger("Cooldown");
    }

    public void Cooldown()
    {
        animator.SetTrigger("Cooldown");
    }
}
