using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlatformerController : BaseController
{
    [Header("낙사 판정 설정")]
    [SerializeField] private float deathYThreshold = -13f;

    [Header("점프 관련 설정")]
    [SerializeField] protected float jumpForce = 6f;
    [SerializeField] protected LayerMask groundLayer;

    protected bool isGrounded = false;
    public AudioClip jumpClip;
    protected virtual void Update()
    {
        base.Update();

        if (transform.position.y < deathYThreshold)
        {
            Death();
        }
    }
    protected virtual void FixedUpdate()
    {
        base.FixedUpdate();
        CheckGrounded();
    }

    protected override void HandleAction()
    {

    }

    protected void Jump()
    {
        if (isGrounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);

            if(jumpClip != null)
                SoundManager.PlayClip(jumpClip);
        }
    }

    private void CheckGrounded()
    {
        isGrounded = _rigidbody.IsTouchingLayers(groundLayer);
    }
    protected override void Movment(Vector2 direction)
    {
        float moveX = direction.x * statHandler.Speed;
        float moveY = _rigidbody.velocity.y;

        if (knockbackDuration > 0.0f)
        {
            moveX *= 0.2f;
            moveX += knockback.x;
        }

        _rigidbody.velocity = new Vector2(moveX, moveY);
        animationHandler?.Move(new Vector2(moveX, 0));
    }


}
