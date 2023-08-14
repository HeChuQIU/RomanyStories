using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainUI : MonoBehaviour
{
    VisualElement root;

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
    }

    private void Start()
    {
        root.Q<VisualElement>("Start").RegisterCallback<ClickEvent>(ev => { SceneManager.LoadScene("Map"); });
        root.Q<VisualElement>("Quit").RegisterCallback<ClickEvent>(ev => { Application.Quit(); });
    }
}