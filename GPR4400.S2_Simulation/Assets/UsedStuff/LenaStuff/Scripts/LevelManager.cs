﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private float delay = 5f;
    public Image Black;

    private void Start()
    {
        Black.canvasRenderer.SetAlpha(0.0f);
    }

    private void OnMouseEnter()
    {    
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        Black.CrossFadeAlpha(1, delay, false);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("SampleScene");
    }
}
