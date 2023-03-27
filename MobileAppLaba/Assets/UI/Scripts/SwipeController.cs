using System;
using UnityEngine;
using UnityEngine.UI;

public enum SwipeDirection
{
    Left,
    Right,
    Up,
    Down
}

public class SwipeController : MonoBehaviour
{      
    [SerializeField] float swipeThreshold = 50.0f; // Порог свайпа
    [SerializeField] private float transitionSpeed = 10.0f; // Скорость перехода между экранами

    public event EventHandler<SwipeDirection> Swiped;

    private Vector2 _start;
    private Vector2 _end;

    private void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("Start");
            _start = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Debug.Log("End");
            _end = Input.GetTouch(0).position;
            if(_end.x < _start.x)
            {
                Debug.Log("Left");
                Swiped?.Invoke(this, SwipeDirection.Left);
                return;
            }

            if (_end.x > _start.x)
            {
                Debug.Log("Right");
                Swiped?.Invoke(this, SwipeDirection.Right);
                return;
            }
        }
    }
}
