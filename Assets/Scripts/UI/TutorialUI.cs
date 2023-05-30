using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour {

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

    private void Start() {
        GameInput.Instance.OnBindingRebind += GameInput_OnBindingRebind;
        KitchenGameManager.Instance.OnLocalPlayerReadyChanged += KitchenGameManager_OnLocalPlayerReadyChanged; 
        
        UpdateVisual();

        Show();
    }

    private void KitchenGameManager_OnLocalPlayerReadyChanged(object sender, EventArgs e) {
        if (KitchenGameManager.Instance.IsLocalPlayerReady()) {
            Hide();
        }
    }
    
    private void GameInput_OnBindingRebind(object sender, EventArgs e) {
        UpdateVisual();
    }

    private void UpdateVisual() {
        keyMoveUpText.SetText(GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up));
        keyMoveDownText.SetText(GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down));
        keyMoveLeftText.SetText(GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left));
        keyMoveRightText.SetText(GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right));
        keyInteractText.SetText(GameInput.Instance.GetBindingText(GameInput.Binding.Interact));
        keyInteractAltText.SetText(GameInput.Instance.GetBindingText(GameInput.Binding.InteractAlternate));
        keyPauseText.SetText(GameInput.Instance.GetBindingText(GameInput.Binding.Pause));
        keyGamepadInteractText.SetText(GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Interact));
        keyGamepadInteractAltText.SetText(GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_InteractAlternate));
        keyGamepadPauseText.SetText(GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Pause));
        
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

    

}
