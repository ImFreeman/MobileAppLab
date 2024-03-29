using System;
using UnityEngine;

public enum SwipeDirection
{
    Left,
    Right,
    Up,
    Down
}

public class SwipeController : MonoBehaviour
{
    public event EventHandler<SwipeDirection> Swiped;

    private Vector2 _start;
    private Vector2 _end;

    private void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {           
            _start = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {            
            _end = Input.GetTouch(0).position;
            if(_end.x < _start.x)
            {                
                Swiped?.Invoke(this, SwipeDirection.Left);
                return;
            }

            if (_end.x > _start.x)
            {                
                Swiped?.Invoke(this, SwipeDirection.Right);
            }
        }
    }
}
