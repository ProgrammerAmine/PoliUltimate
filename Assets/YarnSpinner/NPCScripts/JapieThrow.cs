using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class JapieThrow : MonoBehaviour
{
public Animator animator;
[YarnCommand("JapieThrow")]
    public void japieThrow()
        {
            Debug.Log($"Japie werpt traangas.");
            animator.SetTrigger("Throw");
        }
}
