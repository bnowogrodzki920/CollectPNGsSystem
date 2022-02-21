using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CollectPNGs
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField]
        private Image image;
        [SerializeField]
        private TMP_Text fileNameText;
        [SerializeField]
        private TMP_Text timeSinceCreatedText;

        public void SetData(Sprite sprite, string fileName, string timeSinceCreated)
        {
            image.sprite = sprite;
            fileNameText.text = fileName;
            timeSinceCreatedText.text = timeSinceCreated;
        }

        public void SetData(SpriteInfo spriteInfo)
        {
            image.sprite = spriteInfo.sprite;
            fileNameText.text = spriteInfo.name;
            timeSinceCreatedText.text = spriteInfo.timeSinceCreated;
        }
    }
}