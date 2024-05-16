using UnityEngine;
using UnityEngine.UIElements;

public class VirtualJoystick : MonoBehaviour
{
    private VisualElement m_JoystickBack1;
    private VisualElement m_JoystickHandle1;
    private VisualElement m_JoystickBack2;
    private VisualElement m_JoystickHandle2;
    private Vector2 m_JoystickPointerDownPosition1;
    private Vector2 m_JoystickDelta1;
    private Vector2 m_JoystickPointerDownPosition2;
    private Vector2 m_JoystickDelta2;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        m_JoystickBack1 = root.Q("JoystickBack1");
        m_JoystickHandle1 = root.Q("JoystickHandle1");
        m_JoystickHandle1.RegisterCallback<PointerDownEvent>(OnPointerDown1);
        m_JoystickHandle1.RegisterCallback<PointerUpEvent>(OnPointerUp1);
        m_JoystickHandle1.RegisterCallback<PointerMoveEvent>(OnPointerMove1);
        //ha suck ot rahul

        m_JoystickBack2 = root.Q("JoystickBack2");
        m_JoystickHandle2 = root.Q("JoystickHandle2");
        m_JoystickHandle2.RegisterCallback<PointerDownEvent>(OnPointerDown2);
        m_JoystickHandle2.RegisterCallback<PointerUpEvent>(OnPointerUp2);
        m_JoystickHandle2.RegisterCallback<PointerMoveEvent>(OnPointerMove2);
    }

    void Update()
    {
        PlayerController.moveX = m_JoystickDelta1.x;
        PlayerController.moveY = -m_JoystickDelta1.y;
        
        PlayerCam.mouseX = m_JoystickDelta2.x;
        PlayerCam.mouseY = -m_JoystickDelta2.y;
    }

    void OnPointerDown1(PointerDownEvent e)
    {
        m_JoystickHandle1.CapturePointer(e.pointerId);
        m_JoystickPointerDownPosition1 = e.position;
    }

    void OnPointerUp1(PointerUpEvent e)
    {
        m_JoystickHandle1.ReleasePointer(e.pointerId);
        m_JoystickHandle1.transform.position = Vector3.zero;
        m_JoystickDelta1 = Vector2.zero;
    }

    void OnPointerMove1(PointerMoveEvent e)
    {
        if (m_JoystickHandle1.HasPointerCapture(e.pointerId))
        {
            var pointerCurrentPosition = (Vector2)e.position;
            var pointerMaxDelta = (m_JoystickBack1.worldBound.size - m_JoystickHandle1.worldBound.size) / 2;
            var pointerDelta = Clamp(pointerCurrentPosition - m_JoystickPointerDownPosition1, -pointerMaxDelta,
                pointerMaxDelta);
            m_JoystickHandle1.transform.position = pointerDelta;
            m_JoystickDelta1 = pointerDelta / pointerMaxDelta;
        }
    }

    void OnPointerDown2(PointerDownEvent e)
    {
        m_JoystickHandle2.CapturePointer(e.pointerId);
        m_JoystickPointerDownPosition2 = e.position;
    }

    void OnPointerUp2(PointerUpEvent e)
    {
        m_JoystickHandle2.ReleasePointer(e.pointerId);
        m_JoystickHandle2.transform.position = Vector3.zero;
        m_JoystickDelta2 = Vector2.zero;
    }

    void OnPointerMove2(PointerMoveEvent e)
    {
        if (m_JoystickHandle2.HasPointerCapture(e.pointerId))
        {
            var pointerCurrentPosition = (Vector2)e.position;
            var pointerMaxDelta = (m_JoystickBack2.worldBound.size - m_JoystickHandle2.worldBound.size) / 2;
            var pointerDelta = Clamp(pointerCurrentPosition - m_JoystickPointerDownPosition2, -pointerMaxDelta,
                pointerMaxDelta);
            m_JoystickHandle2.transform.position = pointerDelta;
            m_JoystickDelta2 = pointerDelta / pointerMaxDelta;
        }
    }

    static Vector2 Clamp(Vector2 v, Vector2 min, Vector2 max) =>
        new Vector2(Mathf.Clamp(v.x, min.x, max.x), Mathf.Clamp(v.y, min.y, max.y));
}
