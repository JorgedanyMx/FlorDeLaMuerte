using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLightManager : MonoBehaviour
{
    
    Light2D light2D;
    void Start()
    {
        light2D = GetComponent<Light2D>();
    }
    public void SetBackColor()
    {
        light2D.color = new Color(.2f, .2f, .2f);
    }
    public void SetFinaleColor()
    {
        light2D.color = new Color(1f,1f,1f);
    }
}
