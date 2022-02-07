using System.Collections.Generic;
using System.Drawing;
using BrightIdeasSoftware;

namespace LogViewer
{
    public class HighlightTextColorRenderer : HighlightTextRenderer
    {
        protected override void DrawTextGdiPlus(Graphics g, Rectangle r, string txt)
        {
            base.DrawTextGdiPlus(g, r, txt);
        }
    }
}