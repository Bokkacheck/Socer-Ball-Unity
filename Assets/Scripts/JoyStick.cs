using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    [SerializeField]
    private Image backCircle;
    [SerializeField]
    private Image circle;
    private Vector3 inputVector;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(backCircle.rectTransform, eventData.position, eventData.pressEventCamera,out position))
        {
            position.x = position.x / (backCircle.rectTransform.sizeDelta.x);
            position.y =position.y / (backCircle.rectTransform.sizeDelta.y);
            inputVector = new Vector3(position.x*2, 0, position.y*2);
            inputVector = inputVector.magnitude > 1.0f ? inputVector.normalized : inputVector;
            circle.rectTransform.anchoredPosition = new Vector3(inputVector.x * backCircle.rectTransform.sizeDelta.x / 3, inputVector.z * backCircle.rectTransform.sizeDelta.y/3, 0f);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        circle.rectTransform.anchoredPosition = Vector3.zero;
        inputVector = Vector3.zero;
    }
    public Vector3 PerformMovement()
    {
        return inputVector;
    }
}
