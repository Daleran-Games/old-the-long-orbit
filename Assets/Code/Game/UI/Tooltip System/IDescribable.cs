using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLongOrbit
{
    public interface IDescribable
    {
        string GetRichTextBasicInfo();
        int GetPriority();
    }

}
