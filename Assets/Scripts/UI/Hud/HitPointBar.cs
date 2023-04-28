using System.Collections.Generic;
using Assets.Classes;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.U2D;
using UnityEngine.UIElements;
using Logger = Assets.Classes.Logger;

namespace Assets.Scripts.UI
{
    public class HitPointBar : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<HitPointBar>
        {
        }

        private EntityData EntityData { get; set; }
        private List<VisualElement> flames = new();
        private static Sprite _flameSprite;
        private static Sprite _heartSprite;
        private bool isAssetReady = false;


        private async void Load()
        {
            if (_flameSprite != null && _heartSprite != null) return;
            var handle = Addressables.LoadAssetAsync<SpriteAtlas>("Assets/Arts/UI/HUD.png");
            await handle.Task;
            var atlas = handle.Result;
            _flameSprite = atlas.GetSprite("flame");
            _heartSprite = atlas.GetSprite("heart");
        }

        public HitPointBar()
        {
            AddToClassList("hitPointBar");
        }

        public HitPointBar(EntityData entityData) : this()
        {
            EntityData = entityData;
            EntityData.OnEntityDataChanged += (sender, e) =>
            {
                if (e.PropertyName != nameof(EntityData.CurrentHitPoint) &&
                    e.PropertyName != nameof(EntityData.MaxHitPoint))
                    return;
                Update(sender as EntityData);
            };
            Update(entityData);
        }

        private void Update(EntityData entityData)
        {
            Clear();
            for (var i = 0; i < EntityData.MaxHitPoint; i++)
            {
                if (i < EntityData.CurrentHitPoint)
                {
                    Add(GetFlame(true));
                }
                else
                {
                    Add(GetFlame(false));
                }
            }
        }


        private static VisualElement GetFlame(bool isHeart = false)
        {
            var ve = new VisualElement();
            ve.AddToClassList("flame");
            ve.style.backgroundImage = _flameSprite.texture;
            var heart = GetHeart();
            if (!isHeart)
                heart.style.display = DisplayStyle.None;
            ve.Add(heart);
            return ve;
        }

        private static VisualElement GetHeart()
        {
            var ve = new VisualElement();
            ve.AddToClassList("heart");
            ve.style.backgroundImage = _heartSprite.texture;
            return ve;
        }
    }
}