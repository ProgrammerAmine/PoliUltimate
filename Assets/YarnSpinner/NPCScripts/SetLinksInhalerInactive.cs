using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SetLinksInhalerInactive : MonoBehaviour
{
public GameObject inhaler;
[YarnCommand("SetLinksInhalerInactive")]
    public void setLinksInhalerInactive() {
        Debug.Log($"Linkse inhaler verdwijnt");
        inhaler.SetActive(false);
    }
}
