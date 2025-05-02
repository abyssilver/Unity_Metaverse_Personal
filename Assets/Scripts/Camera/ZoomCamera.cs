using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{

    public float zoomSpeed = 2f;

    public float minSize = 3f;
    public float maxSize = 9f;

    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
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
    }
}
