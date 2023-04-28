using System.Threading.Tasks;
using Assets.Classes;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UIElements;
using Logger = Assets.Classes.Logger;

namespace Assets.Scripts.UI
{
    public class Hud : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<Hud>
        {
        }

        private EntityData entityData;
        private HitPointBar hitPointBar;
        private readonly VisualElement[] visualElements = new VisualElement[4];
        private static StyleSheet _styleSheet;

        private async Task Load()
        {
            if (_styleSheet == null)
            {
                var handle = Addressables.LoadAssetAsync<StyleSheet>("Assets/Data/UI/Hud.uxml");
                await handle.Task;
                _styleSheet = handle.Result;
            }

            styleSheets.Add(_styleSheet);
        }

        public Hud()
        {
            var task = Load();
            Logger.Log(_styleSheet);
        }

        public Hud(EntityData entityData) : this()
        {
            this.entityData = entityData;
            hitPointBar = new HitPointBar();
            for (var i = 0; i < 4; i++)
            {
                var ve = new VisualElement();
                switch (i)
                {
                    case 0:
                        ve.AddToClassList("left-top");
                        break;
                    case 1:
                        ve.AddToClassList("right-top");
                        break;
                    case 2:
                        ve.AddToClassList("left-bottom");
                        break;
                    case 3:
                        ve.AddToClassList("right-bottom");
                        break;
                }

                Add(ve);
                visualElements[i] = ve;
            }
            visualElements[2].hierarchy.Add(new HitPointBar(entityData));
        }
    }
}