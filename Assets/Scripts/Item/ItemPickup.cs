using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    [SerializeField] private int extraArrowCount = 1;
    [SerializeField] private float extraPower = 1f;

    [SerializeField] private float destroyDelay = 0.5f;

    private Animator animator;

    public AudioClip openSoundClip;
    private static readonly int IsOpen = Animator.StringToHash("IsOpen");
    private Collider2D[] allColliders;

    private void Awake()
    {
        allColliders = GetComponents<Collider2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        var rangeHandler = other.GetComponentInChildren<RangeWeaponHandler>();
        if (rangeHandler != null)
        {
            foreach (var c in allColliders)
            {
                if (!c.isTrigger)
                {
                    c.enabled = false;
                }
            }
            var rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0f;
            }
                OpenAnimation();

            if (openSoundClip != null)
                SoundManager.PlayClip(openSoundClip);

            int choice = Random.Range(0, 2);
            if (choice == 0)
            {
                rangeHandler.AddProjectiles(extraArrowCount);
                Debug.Log($"æ∆¿Ã≈€ »πµÊ! πﬂªÁ√º ºˆ +{extraArrowCount}");
            }
            else
            {
                rangeHandler.AddPower(extraPower);
                Debug.Log($"æ∆¿Ã≈€ »πµÊ! ∆ƒøˆ +{extraPower}");
            }

        }

        StartCoroutine(DestroyAfterDelay());

    }

    public void OpenAnimation()
    {
        animator.SetTrigger(IsOpen);
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }
}
