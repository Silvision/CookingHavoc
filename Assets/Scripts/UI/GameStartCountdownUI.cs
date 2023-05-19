using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI countdownText;

    private void Start() {
        KitchenGameManager.Instance.OnStateChanged += KitchenManager_OnStateChanged;

        Hide();
    }

    private void KitchenManager_OnStateChanged(object sender, EventArgs e) {
        if (KitchenGameManager.Instance.IsCountdownToStartActive()) {
            Show();
        } else {
            Hide();
        }
    }

    private void Update() {
        countdownText.text = Mathf.Ceil(KitchenGameManager.Instance.GetCountdownToStartTimer()).ToString();
    }

    private void Hide() {
        countdownText.gameObject.SetActive(false);
    }

    private void Show() {
        countdownText.gameObject.SetActive(true);
    }
}
