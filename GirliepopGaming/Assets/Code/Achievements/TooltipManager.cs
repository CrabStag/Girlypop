using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI tooltipText;
    public RectTransform backgroundRect;
    public Vector2 padding = new Vector2(8, 8);

    public static Tooltip instance;

    private void Awake()
    {
        instance = this;
        HideTooltip();
    }

    private void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform.parent.GetComponent<RectTransform>(),
            Input.mousePosition,
            null, // null if using Screen Space - Overlay canvas
            out localPoint
        );
        transform.localPosition = localPoint;
    }

    public void ShowTooltip(string description)
    {
        gameObject.SetActive(true);
        tooltipText.text = description;

        Vector2 textSize = new Vector2(tooltipText.preferredWidth, tooltipText.preferredHeight);
        backgroundRect.sizeDelta = textSize + padding;
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }
}
