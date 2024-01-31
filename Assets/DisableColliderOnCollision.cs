using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableColliderOnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        // destroyt alleen de bovenste collider !!!
        Destroy(GetComponent<BoxCollider>());
    }
}
