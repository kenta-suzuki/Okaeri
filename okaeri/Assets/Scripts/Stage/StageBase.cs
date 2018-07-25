using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures.TransformGestures;

public abstract class StageBase : MonoBehaviour
{
    [SerializeField]
    Camera GameCamera;
    [SerializeField]
    TransformGesture TransformGesture;
    [SerializeField]
    List<ItemButton> itemButtons;

    protected StageModel model;

    const float LIMIT_CAMERA_POS_UP_Y = 2;
    const float LIMIT_CAMERA_POS_RIGHT_X = 7;
    const float LIMIT_CAMERA_POS_BOTTOM_Y = -2;
    const float LIMIT_CAMERA_POS_LEFT_X = -7;

    const float CAMERA_SIZE = 3;

    float currentCameraSize;
    float baseDistance = 0;

    public void Initialize(int stageId)
    {
        model = GameModel.Instance.Model.GetStageModel(stageId);
    }

	private void Start()
	{
        currentCameraSize = CAMERA_SIZE;
        itemButtons.ForEach(i => i.Pressed += () => OnClickItem());
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
        if (TransformGesture.NumPointers >= 2)
        {
            baseDistance = Vector3.Distance(TransformGesture.ActivePointers[0].Position, TransformGesture.ActivePointers[1].Position);
        }
    }

    void OnTransfromed(object obj, EventArgs args)
    {
        if (TransformGesture.NumPointers >= 2)
        {
            //拡大するときに画面外が写りそうな場合はずらす処理を追加
            var firstTouch = TransformGesture.ActivePointers[0];
            var secondTouch = TransformGesture.ActivePointers[1];
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
            else if (newPosition.y < LIMIT_CAMERA_POS_BOTTOM_Y + size) newPosition = new Vector2(newPosition.x, LIMIT_CAMERA_POS_BOTTOM_Y + size);
            if (newPosition.x > LIMIT_CAMERA_POS_RIGHT_X + size) newPosition = new Vector2(LIMIT_CAMERA_POS_RIGHT_X + size, newPosition.y);
            else if (newPosition.x < LIMIT_CAMERA_POS_LEFT_X - size) newPosition = new Vector2(LIMIT_CAMERA_POS_LEFT_X - size, newPosition.y);

            GameCamera.transform.localPosition = new Vector3(newPosition.x, newPosition.y, -4);
        }
    }

    void OnTransfromFinished(object obj, EventArgs args)
    {
        currentCameraSize = GameCamera.orthographicSize;
    }

    protected virtual void OnClickItem(){}
}
