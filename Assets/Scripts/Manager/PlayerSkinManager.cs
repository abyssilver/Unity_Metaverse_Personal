using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSkinManager : MonoBehaviour
{
    [Header("Animator Controller ���")]
    [SerializeField] private RuntimeAnimatorController[] skinControllers;

    [Header("Skin UI �ǳ�")]
    [SerializeField] private GameObject skinPanel;

    [Header("UI ��ư")]
    [SerializeField] private Button openButton;
    [SerializeField] private Button prevButton;
    [SerializeField] private Button nextButton;

    [Header("�̸����� �̹��� �� ��������Ʈ")]
    [SerializeField] private Image previewImage;
    [SerializeField] private Sprite[] previewSprites;

    private int currentIndex;
    private const string PrefKey = "SelectedSkinIndex";

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        currentIndex = PlayerPrefs.GetInt(PrefKey, 0);

        openButton.onClick.AddListener(TogglePanel);
        prevButton.onClick.AddListener(OnPrevSkin);
        nextButton.onClick.AddListener(OnNextSkin);

        skinPanel.SetActive(false);

        // ���� �ε�� ������ �� �÷��̾ ��Ų ����
        SceneManager.sceneLoaded += OnSceneLoaded;

        // ó�� �ε�� ������ ����
        ApplySkinToCurrentScene();
        RefreshPreview();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ApplySkinToCurrentScene();
    }

    public void TogglePanel()
    {
        skinPanel.SetActive(!skinPanel.activeSelf);
    }

    private void OnPrevSkin()
    {
        if (skinControllers.Length == 0) return;
        currentIndex = (currentIndex - 1 + skinControllers.Length) % skinControllers.Length;
        SaveAndApply();
    }

    private void OnNextSkin()
    {
        if (skinControllers.Length == 0) return;
        currentIndex = (currentIndex + 1) % skinControllers.Length;
        SaveAndApply();
    }

    private void SaveAndApply()
    {
        PlayerPrefs.SetInt(PrefKey, currentIndex);
        PlayerPrefs.Save();
        ApplySkinToCurrentScene();
        RefreshPreview();
    }

    // �±׷� �÷��̾� ã��
    private void ApplySkinToCurrentScene()
    {
        var player = GameObject.FindWithTag("Player");
        if (player == null) return;

        var mainSprite = player.transform.Find("MainSprite");
        if (mainSprite == null) return;

        var animator = mainSprite.GetComponent<Animator>();
        if (animator == null) return;

        animator.runtimeAnimatorController = skinControllers[currentIndex];
    }

    private void RefreshPreview()
    {
        if (previewImage != null && previewSprites != null && previewSprites.Length == skinControllers.Length)
        {
            previewImage.sprite = previewSprites[currentIndex];
        }
    }
}
