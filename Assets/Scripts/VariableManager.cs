using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class VariableManager : MonoBehaviour
{
    private InMemoryVariableStorage variableStorage;
    [SerializeField] private ShaderColorManager shaderColorManager;
    private void Awake() {
        variableStorage = FindObjectOfType<InMemoryVariableStorage>();
    }

    public void GetPlayerSide() {
        float temp;
        variableStorage.TryGetValue<float>("$right_side", out temp);

        Debug.Log($"The right side value is: {temp}");
        shaderColorManager.CharacterValue = temp/20 + 0.5f;
    }
}
