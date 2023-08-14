using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Classes
{
    [Serializable]
    public class DialogData
    {
        private DialogData(List<(string speakingRole, string text)> dialogTexts) =>
            DialogTexts = dialogTexts;

        public List<(string speakingRole, string text)> DialogTexts { get; }

        public static DialogData Create(List<(string speakingRole, string text)> dialogTexts) => new(dialogTexts);
    }
}