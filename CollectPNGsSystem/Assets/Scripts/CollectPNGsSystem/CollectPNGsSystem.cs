using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.IO;
using System;

namespace CollectPNGs
{
    public class CollectPNGsSystem : MonoBehaviour
    {
        [SerializeField]
        private CollectPNGsSystemView view;
        [SerializeField]
        private string dataPath = "/Resources";

        private void Awake()
        {
            dataPath = Application.dataPath + dataPath;
            OnRefreshContent();
        }

        public void OnRefreshContent()
        {
            List<Texture> collectedTextures = GetTextures();
            string[] fileDirectories = Directory.GetFiles(dataPath);
            
            List<TextureInfo> fileInfos = new List<TextureInfo>();

            for (int i = 0; i < fileDirectories.Length; i++)
            {
                if (fileDirectories[i].Contains(".meta")) continue;
                fileInfos.Add(new TextureInfo(collectedTextures[i].name, Directory.GetCreationTime(fileDirectories[i]), collectedTextures[i]));
            }

            view.SetData(fileInfos);
        }

        private List<Texture> GetTextures()
        {
            return Resources.LoadAll<Texture>("").ToList();
        }
    }

    public struct TextureInfo
    {
        public string name;
        public DateTime dateCreated;
        public Texture texture;

        public TextureInfo(string name, DateTime dateCreated, Texture texture)
        {
            this.name = name;
            this.dateCreated = dateCreated;
            this.texture = texture;
        }

        public override string ToString()
        {
            return name + dateCreated;
        }
    }
}