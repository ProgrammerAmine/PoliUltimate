using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class JannekeTalking : MonoBehaviour
{
public Animator animator;
[YarnCommand("JannekeTalking")]
    public void jannekeTalking() {
        Debug.Log($"Janneke begint met je te praten.");
        // animator.SetTrigger("Talking");
        animator.SetBool("Talking", true);
    }
[YarnCommand("JannekeStopTalking")]
    public void jannekeStopTalking() {
        Debug.Log($"Janneke stopt met je te praten.");
        animator.SetBool("Talking", false);
    }
[YarnCommand("JannekeGive")]
    public void jannekeGive() {
        Debug.Log($"Janneke geeft je een flyer.");
        animator.SetTrigger("Give");
    }
}
