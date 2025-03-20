using UnityEngine;

public class HoverShader2D : MonoBehaviour
{
    public Shader defaultShader;  // The normal shader (default Unity sprite shader)
    public Shader hoverShader;    // The shader you want when hovering

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Ensure we start with the default shader
        if (defaultShader == null)
        {
            defaultShader = Shader.Find("Sprites/Default"); // Unity's built-in sprite shader
        }

        spriteRenderer.material.shader = defaultShader;
    }

    void OnMouseEnter()
    {
        // Change shader when mouse is over the sprite
        if (hoverShader != null)
        {
            spriteRenderer.material.shader = hoverShader;
        }
    }

    void OnMouseExit()
    {
        // Revert to default shader when mouse leaves
        if (defaultShader != null)
        {
            spriteRenderer.material.shader = defaultShader;
        }
    }
}
