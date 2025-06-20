using UnityEngine;
using UnityEngine.EventSystems;

public class AchievementHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string description;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.instance.ShowTooltip(description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.instance.HideTooltip();
    }

}
