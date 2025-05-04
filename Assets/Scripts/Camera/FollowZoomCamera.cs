using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FollowZoomCamera : MonoBehaviour
{

    public Transform target;
    //float offsetX;
    //float offsetY;

    public float zoomSpeed = 2f;
    public float minSize = 3f;
    public float maxSize = 9f;

    public Vector2 minClamp;
    public Vector2 maxClamp;

    private Camera _camera;

   
    private Bounds _bounds;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;

        //if (target != null)
        //{
        //    offsetX = transform.position.x - target.position.x;
        //    offsetY = transform.position.y - target.position.y;
        //}
    }

    // Update is called once per frame
    void Update()
    {

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0f)
        {
            _camera.orthographicSize -= scroll * zoomSpeed;
            _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, minSize, maxSize);
        }

        if (target != null)
        {
            //Vector3 pos = transform.position;
            //pos.x = target.position.x + offsetX;
            //pos.y = target.position.y + offsetY;
            //transform.position = pos;

            Vector3 pos = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = pos;
        }

        if (target == null)
            return;

        // 카메라 크기 계산
        float halfHeight = _camera.orthographicSize;
        float halfWidth = halfHeight * _camera.aspect;

        // 플레이어 위치 기준으로 Clamp 적용
        float clampedX = Mathf.Clamp(target.position.x, minClamp.x + halfWidth, maxClamp.x - halfWidth);
        float clampedY = Mathf.Clamp(target.position.y, minClamp.y + halfHeight, maxClamp.y - halfHeight);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}

