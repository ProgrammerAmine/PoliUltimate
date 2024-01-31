using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBurgemeesterColor : MonoBehaviour
{
    private Color BurgemeesterColor = new Color(0.25f, 0.75f, 1.0f, 1.0f);

void Start()
    {
        foreach(Transform child in transform.GetComponentsInChildren<Transform>())
            {
                if(!child.TryGetComponent<Renderer>(out Renderer rend)) continue;
                    rend.material.SetColor("_MainColor", BurgemeesterColor);
                    rend.material.SetFloat("_xDitherStretch", 1);
                    rend.material.SetFloat("_yDitherStretch", 1);
            }
    }
}
