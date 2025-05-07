using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSkinManager : MonoBehaviour
{
    [Header("Animator Controller 목록")]
    [SerializeField] private RuntimeAnimatorController[] skinControllers;

    [Header("Skin UI 판넬")]
    [SerializeField] private GameObject skinPanel;

    [Header("UI 버튼")]
    [SerializeField] private Button openButton;
    [SerializeField] private Button prevButton;
    [SerializeField] private Button nextButton;

    [Header("미리보기 이미지 및 스프라이트")]
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

        // 씬이 로드될 때마다 새 플레이어에 스킨 적용
        SceneManager.sceneLoaded += OnSceneLoaded;

        // 처음 로드된 씬에도 적용
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

    // 태그로 플레이어 찾기
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
