using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomiseIdle : MonoBehaviour
{
    private List<string> AnimationNames = new List<string>
    {
        "EnterA", "EnterB", "EnterC",
    };
    private IEnumerator chooseRandomAnimation(Animator animator)
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 4.0f));
        animator.SetTrigger(AnimationNames[Random.Range(0, 3)]);
        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
        StartCoroutine(waitForAnimation(animationLength, animator));
    }
     private IEnumerator waitForAnimation(float length, Animator animator)
     {
        yield return new WaitForSecondsRealtime(length);
        StartCoroutine(chooseRandomAnimation(animator));
     }
    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(42069);
        foreach(Transform child in transform)
        {
            StartCoroutine(chooseRandomAnimation(child.GetComponent<Animator>()));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
