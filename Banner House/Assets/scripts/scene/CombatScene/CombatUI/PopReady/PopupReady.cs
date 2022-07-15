using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PopupReady : MonoBehaviour
{

    [SerializeField] Button _buttonMain1; // direct to main menu
    [SerializeField] Button _buttonYes2; // stay in the same scene
    [SerializeField] TMP_Text _popupReadyText;
    

    public void Init (Transform canvas, string popupMessage, Action action) {
        _popupReadyText.text = popupMessage;

        //set canvas
        transform.SetParent(canvas);
        transform.localScale = Vector3.one;

        _buttonMain1.onClick.AddListener(() => {
            action();
        });

        _buttonYes2.onClick.AddListener(() => {
            GameObject.Destroy(this.gameObject);
        });
    }
}
