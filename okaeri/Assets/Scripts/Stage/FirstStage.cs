using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TouchScript;
using TouchScript.Gestures;

public class FirstStage : MonoBehaviour
{
    [SerializeField]
    Camera GameCamera;
    [SerializeField]
    TransformGesture TransformGesture;

    const float LIMIT_CAMERA_POS_UP_Y = 2;
    const float LIMIT_CAMERA_POS_RIGHT_X = 7;
    const float LIMIT_CAMERA_POS_BOTTOM_Y = -2;
    const float LIMIT_CAMERA_POS_LEFT_X = -7;

    const float CAMERA_SIZE = 3;

    float currentCameraSize;
    float baseDistance = 0;

	// Use this for initialization
	void Start () 
    {
        currentCameraSize = CAMERA_SIZE;
	}

	private void OnEnable()
	{
        TransformGesture.TransformStarted += OnTransfromStarted;
        TransformGesture.Transformed += OnTransfromed;
        TransformGesture.TransformCompleted += OnTransfromFinished;
	}

	private void OnDisable()
	{
        TransformGesture.TransformStarted -= OnTransfromStarted;
        TransformGesture.Transformed -= OnTransfromed;
        TransformGesture.TransformCompleted -= OnTransfromFinished;
	}

    void OnTransfromStarted(object obj, EventArgs args)
    {
        Debug.LogError(TransformGesture.NumTouches);
        if(TransformGesture.NumTouches >= 2)
        {
            baseDistance = Vector3.Distance(TransformGesture.ActiveTouches[0].Position, TransformGesture.ActiveTouches[1].Position);
        }
    }

    void OnTransfromed(object obj, EventArgs args)
    {
        if(TransformGesture.NumTouches >= 2)
        {
            //拡大するときに画面外が写りそうな場合はずらす処理を追加
            var firstTouch = TransformGesture.ActiveTouches[0];
            var secondTouch = TransformGesture.ActiveTouches[1];
            var dis = Vector3.Distance(firstTouch.Position, secondTouch.Position);
            var size = currentCameraSize * (baseDistance / dis);
            if (size > 4) size = 4;
            else if (size < 1.5f) size = 1.5f;
            GameCamera.orthographicSize = size;
        }
        else
        {
            //ここの処理は色々考える
            var oldCameraPosition = GameCamera.transform.localPosition;
            var newPosition = new Vector2(TransformGesture.LocalDeltaPosition.x + oldCameraPosition.x,
                                          TransformGesture.LocalDeltaPosition.y + oldCameraPosition.y);

            var size = GameCamera.orthographicSize - CAMERA_SIZE;
            if (newPosition.y > (LIMIT_CAMERA_POS_UP_Y - size)) newPosition = new Vector2(newPosition.x, LIMIT_CAMERA_POS_UP_Y - size);
            else if(newPosition.y < LIMIT_CAMERA_POS_BOTTOM_Y + size) newPosition = new Vector2(newPosition.x, LIMIT_CAMERA_POS_BOTTOM_Y + size);
            if (newPosition.x > LIMIT_CAMERA_POS_RIGHT_X + size) newPosition = new Vector2(LIMIT_CAMERA_POS_RIGHT_X + size, newPosition.y);
            else if (newPosition.x < LIMIT_CAMERA_POS_LEFT_X - size) newPosition = new Vector2(LIMIT_CAMERA_POS_LEFT_X - size, newPosition.y); 

            GameCamera.transform.localPosition = new Vector3(newPosition.x, newPosition.y, -4);
        }
    }

    void OnTransfromFinished(object obj, EventArgs args)
    {
        currentCameraSize = GameCamera.orthographicSize;
    }
}
