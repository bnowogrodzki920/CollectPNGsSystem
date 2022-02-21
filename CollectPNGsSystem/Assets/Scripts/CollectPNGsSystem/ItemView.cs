using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CollectPNGs
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField]
        private RawImage rawImage;
        [SerializeField]
        private TMP_Text fileNameText;
        [SerializeField]
        private TMP_Text timeSinceCreatedText;

        public void SetData(Texture texture, string fileName, string timeSinceCreated)
        {
            rawImage.texture = texture;
            fileNameText.text = fileName;
            timeSinceCreatedText.text = timeSinceCreated;
        }
    }
}