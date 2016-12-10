using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TheLongOrbit
{
    [CreateAssetMenu(fileName = "NewUIStyle", menuName = "Long Orbit/UI/UI Style", order = 0)]
    public class UIStyle : ScriptableObject
    {
        [Header("Panel Style")]
        public Color PanelColor = Color.black;

        [Header("Text Styles")]
        public TextStyle Heading;
        public TextStyle Subheading;
        public TextStyle Body;
        public TextStyle Footnote;



        [System.Serializable]
        public class TextStyle
        {
            public bool Bold = false;
            public bool Italics = false;
            [Range(1,72)]
            public int FontSize = 10;
            public Color FontColor = Color.white;

            public string ApplyTextSyle(string str)
            {
                string newText = str;

                if (Bold == true)
                {
                    newText = StringRichTextUtilities.BoldString(newText);
                }
                    

                if (Italics == true)
                {
                    newText = StringRichTextUtilities.ItalicString(newText);
                }
                    
                newText = StringRichTextUtilities.SetStringSize(newText, FontSize);
                newText = StringRichTextUtilities.SetStringColor(newText, FontColor);



                return newText;
            }

        }
        
    }
}


