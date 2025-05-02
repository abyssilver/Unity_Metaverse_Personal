using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowZoomCamera : MonoBehaviour
{

    public Transform target;
    float offsetX;
    float offsetY;

    public float zoomSpeed = 2f;
    public float minSize = 3f;
    public float maxSize = 9f;

    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;

        if (target != null)
        {
            offsetX = transform.position.x - target.position.x;
            offsetY = transform.position.y - target.position.y;
        }
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
            Vector3 pos = transform.position;
            pos.x = target.position.x + offsetX;
            pos.y = target.position.y + offsetY;
            transform.position = pos;
        }
    }
}
