using System.Collections;
using UnityEngine;

namespace S3
{
    public class Item_Tag : MonoBehaviour
    {

        public string itemTag;

        void OnEnable()
        {
            SetTag();

        }

        void SetTag()
        {
            if (itemTag == "")
            {
                itemTag = "Untagged";
            }

            transform.tag = itemTag;
        }
    }
}
