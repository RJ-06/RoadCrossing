using UnityEngine;
using UnityEngine.UIElements;

public class VirtualJoystick : MonoBehaviour
{
    private VisualElement m_JoystickBack;
    private VisualElement m_JoystickHandle;
    private Vector2 m_JoystickPointerDownPosition;
    private Vector2 m_JoystickDelta; // Between -1 and 1

    public Rigidbody worldObjectToMove;
    public float worldObjectPushStrength = 5f;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        m_JoystickBack = root.Q("JoystickBack");
        m_JoystickHandle = root.Q("JoystickHandle");
        m_JoystickHandle.RegisterCallback<PointerDownEvent>(OnPointerDown);
        m_JoystickHandle.RegisterCallback<PointerUpEvent>(OnPointerUp);
        m_JoystickHandle.RegisterCallback<PointerMoveEvent>(OnPointerMove);
    }

    void Update()
    {
        if (m_JoystickDelta != Vector2.zero)
             worldObjectToMove.AddForce(new Vector3(m_JoystickDelta.x, 0, -m_JoystickDelta.y) * worldObjectPushStrength);
    }

    void OnPointerDown(PointerDownEvent e)
    {
        m_JoystickHandle.CapturePointer(e.pointerId);
        m_JoystickPointerDownPosition = e.position;
    }

    void OnPointerUp(PointerUpEvent e)
    {
        m_JoystickHandle.ReleasePointer(e.pointerId);
        m_JoystickHandle.transform.position = Vector3.zero;
        m_JoystickDelta = Vector2.zero;
    }

    void OnPointerMove(PointerMoveEvent e)
    {
        if (!m_JoystickHandle.HasPointerCapture(e.pointerId))
            return;
        var pointerCurrentPosition = (Vector2) e.position;
        var pointerMaxDelta = (m_JoystickBack.worldBound.size - m_JoystickHandle.worldBound.size) / 2;
        var pointerDelta = Clamp(pointerCurrentPosition - m_JoystickPointerDownPosition, -pointerMaxDelta,
            pointerMaxDelta);
        m_JoystickHandle.transform.position = pointerDelta;
        m_JoystickDelta = pointerDelta / pointerMaxDelta;
    }

    static Vector2 Clamp(Vector2 v, Vector2 min, Vector2 max) =>
        new Vector2(Mathf.Clamp(v.x, min.x, max.x), Mathf.Clamp(v.y, min.y, max.y));
}
