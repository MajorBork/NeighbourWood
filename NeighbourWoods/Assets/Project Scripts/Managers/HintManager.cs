using System.Collections;
using System.Collections.Generic;
using EasyEditor;
using UnityEngine;
using Manager.Character;

namespace Manager.Hint
{
    public class HintManager : MonoBehaviour
    {
        public Hints[] hints;
        void Start() // Use this for initialization
        {

        }
        void Update() // Update is called once per frame
        {

        }
    }
    [Groups("Base Settings")]
    [System.Serializable]
    public class Hints
    {
        Characters[] characters;
        int Hintnum;
        [TextArea(3, 10)]
        int Text;
    }
}
