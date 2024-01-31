using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColorScript : MonoBehaviour
{
    [Range(0, 1)]
    public float value;
    [SerializeField]
    private ShaderColorManager shaderColorManager;
    // Start is called before the first frame update
    void Update()
    {
        shaderColorManager.CharacterValue = value;
    }

}
