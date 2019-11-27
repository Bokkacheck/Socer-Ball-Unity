using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStickCamera : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    [SerializeField]
    private Image backCircle;
    [SerializeField]
    private Image circle;
    [SerializeField]
    private Image movementJoyStick;
    private Vector3 inputVector;
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(backCircle.rectTransform, eventData.position, eventData.pressEventCamera, out position))
        {
            position.x = position.x / (backCircle.rectTransform.sizeDelta.x);
            inputVector = new Vector3(0, position.x*2,0);
            inputVector = inputVector.magnitude > 1.0f ? inputVector.normalized : inputVector;
            circle.rectTransform.anchoredPosition = new Vector3(inputVector.y * backCircle.rectTransform.sizeDelta.y / 3, 0f, 0f);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        circle.rectTransform.anchoredPosition = Vector3.zero;
        inputVector.y = 0;
    }
    public float ChangeView(float rotateY)
    {
        //if (rotateY != movementJoyStick.transform.rotation.y)
        //{
        //    movementJoyStick.transform.Rotate(0f, 0f, rotateY-movementJoyStick.transform.rotation.y);
        //}
        return inputVector.y;
    }
}
