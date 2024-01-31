using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPolarisationColor : MonoBehaviour
{
    private Color LeftColor = new Color(0.5f, 1.0f, 0.0f, 1.0f);
    private Color RightColor = new Color(0.5f, 0.0f, 1.0f, 1.0f);
    [Range(0.0f, 1.0f)]
    public float PolarisationLeftToRight;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform.GetComponentsInChildren<Transform>())
        {
           if(!child.TryGetComponent<Renderer>(out Renderer rend)) continue;
            rend.material.SetColor("_MainColor", Color.Lerp(LeftColor, RightColor, PolarisationLeftToRight));
            rend.material.SetFloat("_xDitherStretch", PolarisationLeftToRight * 2);
            rend.material.SetFloat("_yDitherStretch", 1 - ((PolarisationLeftToRight - 0.5f) * 2));
        }
    }
}
