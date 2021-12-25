using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    [SerializeField]
    private RectTransform _center;
    [SerializeField]
    private RectTransform _knob;
    [SerializeField]
    private float _range;

    private bool _fixedJoystcik;
    public Vector2 direction;
    private bool _active;
    private Vector2 _pos;

    public GameObject mainChar;
    public float speed;
    void Start()
    {
        ShowJoystick(false);
        _active = false;
    }

    void Update()
    {
     _pos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            ShowJoystick(true);
            _active = true;
            _knob.position = _pos;
            _center.position = _pos;
        }
        else if (Input.GetMouseButton(0))
        {
            _knob.position = _pos;
            _knob.position = _center.position + Vector3.ClampMagnitude(_knob.position - _center.position, _center.sizeDelta.x * _range);

            direction = (_knob.position - _center.position).normalized;
        }

        else _active = false;

        if (!_active)
        {
            ShowJoystick(false);
            direction = Vector2.zero;
        }
        Debug.Log(direction);
        mainChar.transform.Translate(new Vector3(direction.x,0f,direction.y) * speed * Time.deltaTime);
    }

    public void ShowJoystick(bool state)
    {
        _center.gameObject.SetActive(state);
        _knob.gameObject.SetActive(state);
    }
}
