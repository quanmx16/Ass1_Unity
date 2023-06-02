using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Lay_egg", false);
    }
    public void StopLayEgg()
    {
        animator.SetBool("Lay_egg", false);
    }
}
