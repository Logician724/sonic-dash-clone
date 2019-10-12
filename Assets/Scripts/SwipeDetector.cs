using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SwipeDetector : MonoBehaviour
{

    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    private bool detectSwipeAfterRelease = false;
    private float minDistanceForSwipe = 20f;

    public static event Action<SwipeData> OnSwipe = delegate { };
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUpPosition = touch.position;
                fingerDownPosition = touch.position;
            }

            if (!detectSwipeAfterRelease && touch.phase == TouchPhase.Moved)
            {
                fingerDownPosition = touch.position;

            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerDownPosition = touch.position;

            }

        }


    }

    private void DetectSwipe()
    {
        if (isSwipeDetected())
        {
            if (isVerticalSwipe())
            {
                SwipeDirection direction = fingerDownPosition.y - fingerUpPosition.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;

            }
            else
            {
                SwipeDirection direction = fingerDownPosition.x - fingerUpPosition.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;

            }
        }
    }


    private void SendSwipe(SwipeDirection direction)
    {
        SwipeData swipeData = new SwipeData()
        {
            direction = direction,
            startPosition = fingerDownPosition,
            endPosition = fingerUpPosition
        };
        OnSwipe(swipeData);
    }
    private bool isSwipeDetected()
    {
        return VerticalMovementDistance() > minDistanceForSwipe || HorizontalMovementDistance() > minDistanceForSwipe;
    }

    private float VerticalMovementDistance()
    {
        return Math.Abs(fingerDownPosition.y - fingerUpPosition.y);
    }

    private float HorizontalMovementDistance()
    {
        return Math.Abs(fingerDownPosition.x - fingerUpPosition.x);
    }


    private bool isVerticalSwipe()
    {
        return VerticalMovementDistance() > HorizontalMovementDistance();
    }

}



public struct SwipeData
{
    public Vector2 startPosition;
    public Vector2 endPosition;
    public SwipeDirection direction;
}

public enum SwipeDirection
{
    Up,
    Down,
    Left,
    Right
}