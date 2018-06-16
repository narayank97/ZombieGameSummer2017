using System.Collections;
using UnityEngine;

namespace S3
{
    public class Spawn_Activate : MonoBehaviour
    {
        public Transform obj1;
        public Transform obj2;
        public Transform obj3;
        public Transform obj4;
        public Transform obj5;
        public Transform obj6;
        public Transform obj7;
        public Transform obj8;
        public Transform obj9;

        private int count15 = 3;
        private int count17 = 3;
        private int count12 = 3;
        private int count24 = 3;
        private int count35 = 4;
        private int count37 = 3;
        private int count45 = 3;
        private int count56 = 4;
        private int count57 = 4;

        private int obCount15 = 3;
        private int obCount17 = 3;
        private int obCount12 = 3;
        private int obCount24 = 3;
        private int obCount35 = 4;
        private int obCount37 = 3;
        private int obCount45 = 3;
        private int obCount56 = 4;
        private int obCount57 = 4;


        void Update()
        {
           // CheckGates();
        }
        void CheckGates()
        {
           // Debug.Log("Checking gates......");
            Zone1_5Active();//1
            Zone1_7Active();//2
            Zone1_2Active();//3
            Zone2_4Active();//4
            Zone3_5Active();//5
            Zone3_7Active();//6
            Zone4_5Active();//7
            Zone5_6Active();//8
            Zone5_7Active();//9
        }

        public void ReduceChildren(string zoneName)
        {
            if (zoneName == "ChainLink 15")
            {
                obCount15--;
            }
            else if (zoneName == "ChainLink 17")
            {
                obCount17--;
            }
            else if (zoneName == "ChainLink 12")
            {
                obCount12--;
            }
            else if (zoneName == "ChainLink 24")
            {
                obCount24--;
            }
            else if (zoneName == "ChainLink 35")
            {
                obCount35--;
            }
            else if (zoneName == "ChainLink 37")
            {
                obCount37--;
            }
            else if (zoneName == "ChainLink 45")
            {
                obCount45--;
            }
            else if (zoneName == "ChainLink 56")
            {
                obCount56--;
            }
            else if (zoneName == "ChainLink 57")
            {
                obCount57--;
            }
            else
            {
                Debug.Log("Incorrect child name for gate!");
            }
        }

        public bool Zone1_5Active()
        {
            if (obCount15 < count15) { return true; }
            else{ return false; }
        }

        public bool Zone1_7Active()
        {
            if (obCount17 < count17) { return true; }
            else { return false; }
        }

        public bool Zone1_2Active()
        {
            if (obCount12 < count12) { return true; }
            else { return false; }
        }

        public bool Zone2_4Active()
        {
            if (obCount24 < count24) { return true; }
            else { return false; }
        }

        public bool Zone3_5Active()
        {
            if (obCount35 < count35) { return true; }
            else { return false; }
        }

        public bool Zone3_7Active()
        {
            if (obCount37 < count37) { return true; }
            else { return false; }
        }

        public bool Zone4_5Active()
        {
            if (obCount45 < count45) { return true; }
            return false;
        }

        public bool Zone5_6Active()
        {
            
            if (obCount56 < count56) { return true; }
            else { return false; }
        }

        public bool Zone5_7Active()
        {
            if (obCount57 < count57) { return true; }
            else { return false; }
        }


    }
}
