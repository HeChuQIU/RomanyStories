using System;
using System.Collections.Generic;
using Assets.Classes;
using UnityEngine;
using UnityEngine.UIElements;
using Logger = Assets.Classes.Logger;

namespace Assets.Scripts.UI
{
    public class Hud : MonoBehaviour
    {
        [SerializeField] private Player player;

        private VisualElement root;
        private VisualElement leftBottom;
        private VisualElement hitPointBar;
        private VisualElement armorBar;

        [SerializeField] private DialogData dialogData;
        [SerializeField] private int currentDialogTextIndex = 0;
        [SerializeField] private bool isDialoging;

        public bool IsDialoging
        {
            get => isDialoging;
            set => isDialoging = value;
        }

        public int CurrentDialogTextIndex
        {
            get => currentDialogTextIndex;
            set
            {
                currentDialogTextIndex = value;
                if (currentDialogTextIndex >= dialogData.DialogTexts.Count)
                {
                    Time.timeScale = 1;
                    root.Q<VisualElement>("OnDialog").style.display = DisplayStyle.None;
                    root.Q<VisualElement>("OnPlay").style.display = DisplayStyle.Flex;
                    IsDialoging = false;
                }
                else
                {
                    root.Q<Label>("DialogText").text = dialogData.DialogTexts[currentDialogTextIndex].text;
                    root.Q<VisualElement>("Person").Query<VisualElement>()
                        .ForEach(element =>
                        {
                            element.style.display =
                                element.name == dialogData.DialogTexts[currentDialogTextIndex].speakingRole
                                || element.name == "Person"
                                    ? DisplayStyle.Flex
                                    : DisplayStyle.None;
                        });
                    // root.Q<VisualElement>("Person").Q<VisualElement>("Isis").style.display =
                    //     dialogData.DialogTexts[currentDialogTextIndex].speakingRole == "Isis"
                    //         ? DisplayStyle.Flex
                    //         : DisplayStyle.None;
                }
            }
        }

        private void Awake()
        {
            root = GetComponent<UIDocument>().rootVisualElement;
            if (root == null)
                Logger.Log("root is null");
        }

        private void Start()
        {
            leftBottom = root.Q<VisualElement>("LeftBottom");
            if (leftBottom == null)
                Logger.Log("leftBottom is null");
            hitPointBar = leftBottom.Q<VisualElement>("HitPointBar");
            if (hitPointBar == null)
                Logger.Log("hitPointBar is null");
            armorBar = leftBottom.Q<VisualElement>("ArmorBar");
            if (armorBar == null)
                Logger.Log("armorBar is null");
            player.EntityData.OnEntityDataChanged += UpdateHud;

            UpdateHitPointBar(player.EntityData);
            UpdateArmorBar(player.EntityData);
        }

        private void Update()
        {
            if (Input.anyKeyDown && IsDialoging)
                CurrentDialogTextIndex++;
        }

        private void UpdateHud(object sender, EntityDataChangedEventArgs e)
        {
            if (sender is not EntityData data)
                return;
            if (e.PropertyName is nameof(EntityData.MaxHitPoint) or nameof(EntityData.CurrentHitPoint))
            {
                UpdateHitPointBar(data);
            }
            else if (e.PropertyName is nameof(EntityData.MaxArmor) or nameof(EntityData.CurrentArmor))
            {
                UpdateArmorBar(data);
            }
        }

        private void UpdateArmorBar(EntityData data)
        {
            armorBar.Clear();
            for (int i = 0; i < data.MaxArmor; i++)
            {
                var ve = new VisualElement();
                if (i < data.CurrentArmor)
                {
                    ve.Add(new VisualElement());
                }

                armorBar.Add(ve);
            }
        }

        private void UpdateHitPointBar(EntityData data)
        {
            hitPointBar.Clear();
            for (int i = 0; i < data.MaxHitPoint; i++)
            {
                var ve = new VisualElement();
                if (i < data.CurrentHitPoint)
                {
                    ve.Add(new VisualElement());
                }

                hitPointBar.Add(ve);
            }
        }

        public void OpenDialog(DialogData dialogData)
        {
            IsDialoging = true;
            this.dialogData = dialogData;
            Time.timeScale = 0;
            root.Q<VisualElement>("OnDialog").style.display = DisplayStyle.Flex;
            root.Q<VisualElement>("OnPlay").style.display = DisplayStyle.None;
            CurrentDialogTextIndex = 0;
        }
    }
}