using UnityEngine;
using System;

namespace CollectPNGs
{
    public struct SpriteInfo
    {
        public string name;
        public string timeSinceCreated;
        public Sprite sprite;

        public SpriteInfo(string name, string timeSinceCreated, Sprite sprite)
        {
            this.name = name;
            this.timeSinceCreated = timeSinceCreated;
            this.sprite = sprite;
        }

        public override string ToString()
        {
            return name + timeSinceCreated;
        }
    }
}