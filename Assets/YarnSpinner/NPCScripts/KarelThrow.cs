using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class KarelThrow : MonoBehaviour
{
public Animator animator;
[YarnCommand("KarelThrow")]
    public void japieThrow() {
        Debug.Log($"Karel werpt de molotov.");
        animator.SetTrigger("Throw");
    }
}
