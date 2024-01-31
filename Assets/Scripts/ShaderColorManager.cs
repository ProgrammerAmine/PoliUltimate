using UnityEngine;

public class ShaderColorManager : MonoBehaviour
{
    [SerializeField]
    private Color LeftColor;
    [SerializeField]
    private Color RightColor;
    [SerializeField]
    private Renderer rend;
    private float characterValue;
    public float CharacterValue
    {
        get => characterValue;
        set {SetCharacterValue(value);}
    }
    void Start()
    {
        rend = GetComponent<Renderer> ();
        CharacterValue = 0.5f;
    }
    private void SetCharacterValue(float newValue) 
    {
        characterValue = newValue;
        rend.material.SetColor("_MainColor", Color.Lerp(LeftColor, RightColor, characterValue));
        rend.material.SetFloat("_xDitherStretch", (characterValue * 2));
        rend.material.SetFloat("_yDitherStretch", 1 - ((characterValue - 0.5f) * 2));
    }
}