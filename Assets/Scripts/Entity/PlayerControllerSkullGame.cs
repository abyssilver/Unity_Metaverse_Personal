using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSkullGame : BasePlatformerController
{
    private Camera camera;

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        movementDirection = new Vector2(horizontal, 0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }


        Vector2 mouseScreenPos = Input.mousePosition;
        Vector2 mouseWorldPos = camera.ScreenToWorldPoint(mouseScreenPos);
        lookDirection = (mouseWorldPos - (Vector2)transform.position).normalized;

        isAttacking = Input.GetMouseButton(0);
    }
}
