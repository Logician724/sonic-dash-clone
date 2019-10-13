using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSonic : MonoBehaviour
{

    private bool isGrounded = true;
    public float jumpDistance = 2f;
    void Awake()
    {
        SwipeDetector.OnSwipe += HandleSwipeEvent;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            TryToMoveRight();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                TryToMoveLeft();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryToJump();
        }
        
        
    }

    void FixedUpdate()
    {
        
    }

    private void TryToMoveLeft()
    {
        Vector3 sonicPosition = gameObject.transform.position;
        if (sonicPosition.x >= 0f)
        {
            sonicPosition.x -= 2.0f;
            gameObject.transform.position = sonicPosition;
        }
    }
    private void TryToMoveRight()
    {
        Vector3 sonicPosition = gameObject.transform.position;
        if (sonicPosition.x <= 0f)
        {
            sonicPosition.x += 2.0f;
            gameObject.transform.position = sonicPosition;
        }
    }
    public void TryToJump()
    {
        
        if (isGrounded)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpDistance, 0), ForceMode.Impulse);
            
        }

    }
    private void HandleSwipeEvent(SwipeData data)
    {

        switch (data.direction)
        {
            case SwipeDirection.Right:
                TryToMoveRight();
                break;
            case SwipeDirection.Left:
                TryToMoveLeft();
                break;
            case SwipeDirection.Up:
                TryToJump();
                break;
            case SwipeDirection.Down: break;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit()
    {

        isGrounded = false;
    }
}
