using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SetPathwayCrowdInactive : MonoBehaviour
{
    public GameObject PathwayCrowd;
    [YarnCommand("SetPathwayCrowdInactive")]
    public void setPathwayCrowdInactive()
    {
            Debug.Log($"Pathway Crowd verdwijnt.");
            PathwayCrowd.SetActive(false);
    }
}
