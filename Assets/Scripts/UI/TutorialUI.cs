using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keyMoveUpText;
    [SerializeField] private TextMeshProUGUI keyMoveDownText;
    [SerializeField] private TextMeshProUGUI keyMoveLeftText;
    [SerializeField] private TextMeshProUGUI keyMoveRightText;
    [SerializeField] private TextMeshProUGUI keyInteractText;
    [SerializeField] private TextMeshProUGUI keyInteractAltText;
    [SerializeField] private TextMeshProUGUI keyPauseText;
    [SerializeField] private TextMeshProUGUI keyGamepadInteractText;
    [SerializeField] private TextMeshProUGUI keyGamepadInteractAltText;
    [SerializeField] private TextMeshProUGUI keyGamepadPauseText;

    private void Start()
    {
        GameInput.Instance.OnBindingRebind += GameInput_OnBindingRebind;

        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;


        UpdateVisual();
        Show();
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsCountdownToStartActive())
        {
            Hide();
        }
    }

    private void GameInput_OnBindingRebind(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }
    private void UpdateVisual()
    {
        keyMoveUpText.text = GameInput.Instance.GetBindingsText(GameInput.Binding.Move_Up);
        keyMoveDownText.text = GameInput.Instance.GetBindingsText(GameInput.Binding.Move_Down);
        keyMoveLeftText.text = GameInput.Instance.GetBindingsText(GameInput.Binding.Move_Left);
        keyMoveRightText.text = GameInput.Instance.GetBindingsText(GameInput.Binding.Move_Right);
        keyInteractText.text = GameInput.Instance.GetBindingsText(GameInput.Binding.Interact);
        keyInteractAltText.text = GameInput.Instance.GetBindingsText(GameInput.Binding.Interact_Alternate);
        keyPauseText.text = GameInput.Instance.GetBindingsText(GameInput.Binding.Pause);
        keyGamepadInteractText.text = GameInput.Instance.GetBindingsText(GameInput.Binding.Gamepad_Interact);
        keyGamepadInteractAltText.text = GameInput.Instance.GetBindingsText(GameInput.Binding.Gamepad_InteractAlternate);
        keyGamepadPauseText.text = GameInput.Instance.GetBindingsText(GameInput.Binding.Gamepad_Pause);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
