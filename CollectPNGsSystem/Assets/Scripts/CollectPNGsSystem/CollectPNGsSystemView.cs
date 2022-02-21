using System.Collections.Generic;
using UnityEngine;

namespace CollectPNGs
{
    public class CollectPNGsSystemView : MonoBehaviour
    {
        [SerializeField]
        private ItemView itemViewPrefab = null;
        [SerializeField]
        private Transform itemViewsHolder = null;

        private List<ItemView> itemViews = new List<ItemView>();

        public void SetData(List<SpriteInfo> spriteInfos)
        {
            if (spriteInfos.Count == 0)
            {
                Debug.Log("No textures to display!");
                return;
            }

            for (int i = 0; i < spriteInfos.Count; i++)
            {
                if(i < itemViews.Count)
                {
                    itemViews[i].gameObject.SetActive(true);
                    itemViews[i].SetData(spriteInfos[i]);
                }
                else
                {
                    var view = Instantiate(itemViewPrefab, itemViewsHolder);
                    view.SetData(spriteInfos[i]);
                    itemViews.Add(view);
                }
            }

            for (int i = spriteInfos.Count; i < itemViews.Count; i++)
            {
                itemViews[i].gameObject.SetActive(false);
            }
        }
    }
}