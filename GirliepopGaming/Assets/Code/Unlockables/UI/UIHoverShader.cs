using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverShaderUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Shader hoverShader;  // The shader to apply when hovered
    private Shader defaultShader;
    private Material materialInstance;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();

        if (image != null)
        {
            materialInstance = new Material(image.material); // Clone material to avoid affecting all UI elements
            defaultShader = materialInstance.shader;  // Store original shader
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (image != null && hoverShader != null)
        {
            materialInstance.shader = hoverShader;
            image.material = materialInstance;  // Apply shader change
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (image != null && defaultShader != null)
        {
            materialInstance.shader = defaultShader;
            image.material = materialInstance;  // Revert to default shader
        }
    }
}
