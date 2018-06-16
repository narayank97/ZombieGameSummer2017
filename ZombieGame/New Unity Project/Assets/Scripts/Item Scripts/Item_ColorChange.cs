using System.Collections;
using UnityEngine;

namespace S3
{
    public class Item_ColorChange : MonoBehaviour
    {
        private Transform gun0;

        void Start()
        {
            ChangeColor(gun0);
        }

        public void ChangeColor(Transform temp)
        {
            gun0 = temp;

            if(temp.GetComponent<Gun_ApplyDamage>().damage >= 20)
            {
                temp.GetChild(3).GetChild(1).GetComponent<Renderer>().material.color = new Color(0, 299, 200);
            }


        }
    }

}

