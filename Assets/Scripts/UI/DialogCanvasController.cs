using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogCanvasController : MonoBehaviour
{
    [SerializeField] List<string> dialogTexts;
    private TextMeshProUGUI textMeshProUGUI;
    private Animator animator;
    private int dialogIndex = 0;
    void Start()
    {
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDialog()
    {
        SetDialogText(dialogTexts[dialogIndex]);
        dialogIndex++;
    }

    public void HideDialog()
    {
        animator.Play("DialogOut");
    }

    public void SetEmptyDialog()
    {
        SetDialogText("");
    }

    private void SetDialogText(string text)
    {
        textMeshProUGUI.text = text;
        animator.Play("DialogIn");
    }

}
