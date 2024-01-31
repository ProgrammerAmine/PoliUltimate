using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SetMolotovActive : MonoBehaviour
{
    public GameObject Molotov;
    public GameObject MolotovCrowd;
    [YarnCommand("SetMolotovActive")]

    // Start is called before the first frame update
    public void setMolotovActive()
    {
            Debug.Log($"Molotov ontstaat.");
            Molotov.SetActive(true);
            MolotovCrowd.SetActive(false);
    }
}
