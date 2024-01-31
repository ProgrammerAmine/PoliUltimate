using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SetInhalerInactive : MonoBehaviour
{
public GameObject inhaler;
[YarnCommand("SetRechtsInhalerInactive")]
    public void setRechtsInhalerInactive() {
        Debug.Log($"Rechtse inhaler verdwijnt");
        inhaler.SetActive(false);
    }
}
