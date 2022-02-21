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
        [SerializeField, Tooltip("Directory of PNGs folder in the Resources in the Assets folder")]
        private string pngsDatapath = "";

        private void Awake()
        {
            OnRefreshContent();
        }

        public void OnRefreshContent()
        {
            List<Sprite> sprites = GetTextures();
            if(sprites.Count == 0)
            {
                Debug.LogError("Couldn't find any sprites!");
                return;
            }
            sprites.OrderBy(x => x.name);

            string[] fileDirectories = Directory.GetFiles($"{Application.dataPath}/Resources{pngsDatapath}");
            
            List<SpriteInfo> spriteInfos = new List<SpriteInfo>();

            for (int i = 0; i < fileDirectories.Length; i++)
            {
                if (fileDirectories[i].Contains(".meta")) continue;
                spriteInfos.Add(new SpriteInfo(GetFileName(fileDirectories[i]), GetHumanizedTimeSinceCreated(fileDirectories[i]), sprites[i / 2]));
            }

            view.SetData(spriteInfos);
        }

        private List<Sprite> GetTextures()
        {
            return Resources.LoadAll<Sprite>(pngsDatapath).ToList();
        }

        private string GetFileName(string path)
        {
            return path.Split('\\')[1];
        }

        private string GetHumanizedTimeSinceCreated(string path)
        {
            DateTime timeCreated = Directory.GetCreationTime(path);
            DateTime now = DateTime.Now;
            int days = now.DayOfYear - timeCreated.DayOfYear;
            int hours = now.Hour - timeCreated.Hour;
            int minutes = now.Minute - timeCreated.Minute;
            int seconds = now.Second - timeCreated.Second;

            if(days <= 0 && hours <= 0 && minutes <= 0 && seconds <= 10)
            {
                return "Just now";
            }
            else if(days <= 0 && hours <= 0 && minutes <= 0)
            {
                return $"{seconds} seconds ago";
            }
            else if (days <= 0 && hours <= 0)
            {
                return $"{minutes} minutes ago";
            }
            else if (days <= 0)
            {
                return $"{hours} hours ago";
            }

            return $"{days} days ago";
        }
    }
}