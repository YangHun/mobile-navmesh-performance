using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public float Speed;
    public Vector2 nowPos, prePos;
    public Vector3 movePos;

    public float CameraSize;
    public float preDistance;

    private void Start()
    {
        CameraSize = Camera.main.orthographicSize;
        preDistance = 0.0f;
    }

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch[] touch = Input.touches;


            if (touch[0].phase == TouchPhase.Began || touch[1].phase == TouchPhase.Began)
            {
                preDistance = Vector3.Distance(touch[0].position, touch[1].position);
            }


            else if (touch[0].phase == TouchPhase.Moved || touch[1].phase == TouchPhase.Moved)
            {
                float distance = Vector3.Distance(touch[0].position, touch[1].position);

                if (distance > preDistance)
                    Camera.main.orthographicSize -= Speed * 5.0f;
                else if (distance < preDistance)
                    Camera.main.orthographicSize += Speed * 5.0f;

                if (Camera.main.orthographicSize > 10.0f)
                    Camera.main.orthographicSize = 10.0f;
                else if (Camera.main.orthographicSize < 3.0f)
                    Camera.main.orthographicSize = 3.0f;

                preDistance = distance;

            }
        }

        else if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                prePos = touch.position - touch.deltaPosition;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                nowPos = touch.position - touch.deltaPosition;
                movePos = (Vector3)(prePos - nowPos) * Speed;
                Camera.main.transform.Translate(movePos); // 이럴수가 !!!!!!!
                prePos = touch.position - touch.deltaPosition;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
            }
        }
    }
}
