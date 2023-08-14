using System;
using System.Collections.Generic;
using Assets.Classes;
using UnityEngine;

namespace Assets.Scripts
{
    public class DialogTrigger : MonoBehaviour
    {
        private DialogData dialogData;
        [SerializeField] private List<string> speakingRoles;
        [SerializeField] private List<string> texts;

        public Action OnTriggered;

        private void Start()
        {
            dialogData = DialogData.Create(new List<(string speakingRole, string text)>());
            for (var i = 0; i < speakingRoles.Count; i++)
            {
                dialogData.DialogTexts.Add((speakingRoles[i], texts[i]));
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Player>() == GameManager.Instance.Player)
            {
                GameManager.Instance.Hud.OpenDialog(dialogData);
                OnTriggered?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}