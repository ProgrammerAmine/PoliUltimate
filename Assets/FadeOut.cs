using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{

public Animator animator;
[YarnCommand("Restart")]

    public void endgame()
        {
            SceneManager.LoadScene(0);
        }
[YarnCommand("FadeOut")]
    public void fadeout()
        {
            animator.SetTrigger("FadeOut");
        }
}
