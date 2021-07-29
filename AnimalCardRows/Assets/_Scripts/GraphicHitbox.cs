using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace CodeSampleOne
{
    public class GraphicHitbox : Graphic
    {
        protected override void OnPopulateMesh(VertexHelper v)
        {
            v.Clear();
        }
    }
}