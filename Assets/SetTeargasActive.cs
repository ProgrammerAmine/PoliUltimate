using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SetTeargasActive : MonoBehaviour
{
    public GameObject Traangas;
    public GameObject TraangasCrowd;
    [YarnCommand("SetTeargasActive")]

    // Start is called before the first frame update
    public void setTeargasActive()
    {
            Debug.Log($"Traangas ontstaat.");
            Traangas.SetActive(true);
            TraangasCrowd.SetActive(false);
    }
}
