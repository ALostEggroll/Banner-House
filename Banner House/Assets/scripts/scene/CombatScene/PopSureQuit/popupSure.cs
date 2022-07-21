using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class popupSure : MonoBehaviour
{
    [SerializeField] Button _buttonExit1; // direct to main menu
    [SerializeField] Button _buttonCancel2; // stay in the same scene
    [SerializeField] TMP_Text _popupSureText;
    

    public void Init (Transform canvas, string popupMessage, Action action) {
        _popupSureText.text = popupMessage;

        //set canvas
        transform.SetParent(canvas);
        transform.localScale = Vector3.one;

        _buttonExit1.onClick.AddListener(() => {
            action();
        });

        _buttonCancel2.onClick.AddListener(() => {
            GameObject.Destroy(this.gameObject);
        });
    }
}
