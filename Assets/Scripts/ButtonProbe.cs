using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonProbe : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Probe click reached button object: " + gameObject.name);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer entered: " + gameObject.name);
    }
}