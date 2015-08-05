using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using PMDCP.Core;

namespace Client.Logic.Graphics
{
    class StringParser
    {
        public static SdlDotNet.Widgets.CharRenderOptions[] ParseText(SdlDotNet.Widgets.CharRenderOptions[] renderOptions, ref string text)
        {
            List<SdlDotNet.Widgets.CharRenderOptions> newRenderOptions = new List<SdlDotNet.Widgets.CharRenderOptions>(text.Length);
            for (int i = 0; i < text.Length; i++)
            {
                if (renderOptions != null && i < renderOptions.Length)
                {
                    newRenderOptions.Add(renderOptions[i]);
                }
                else
                {
                    newRenderOptions.Add(new SdlDotNet.Widgets.CharRenderOptions(Color.Black));
                }
            }
            //int index = text.IndexOf("[b]");
            //while (index > -1) {
            //    text = text.Remove(index, 3);
            //    newRenderOptions.RemoveRange(index, 3);
            //    int endIndex = text.IndexOf("[/b]");
            //    if (endIndex > -1) {
            //        text = text.Remove(endIndex, 4);
            //        newRenderOptions.RemoveRange(endIndex, 4);
            //        for (int i = index; i < endIndex; i++) {
            //            newRenderOptions[i].Bold = true;
            //        }
            //    }

            //    index = text.IndexOf("[b]");
            //}

            //index = text.IndexOf("[i]");
            //while (index > -1) {
            //    text = text.Remove(index, 3);
            //    newRenderOptions.RemoveRange(index, 3);
            //    int endIndex = text.IndexOf("[/i]");
            //    if (endIndex > -1) {
            //        text = text.Remove(endIndex, 4);
            //        newRenderOptions.RemoveRange(endIndex, 4);
            //        for (int i = index; i < endIndex; i++) {
            //            newRenderOptions[i].Italic = true;
            //        }
            //    }

            //    index = text.IndexOf("[i]");
            //}

            //index = text.IndexOf("[u]");
            //while (index > -1) {
            //    text = text.Remove(index, 3);
            //    newRenderOptions.RemoveRange(index, 3);
            //    int endIndex = text.IndexOf("[/u]");
            //    if (endIndex > -1) {
            //        text = text.Remove(endIndex, 4);
            //        newRenderOptions.RemoveRange(endIndex, 4);
            //        for (int i = index; i < endIndex; i++) {
            //            newRenderOptions[i].Underline = true;
            //        }
            //    }

            //    index = text.IndexOf("[u]");
            //}

            int index = text.IndexOf("[c]");
            while (index > -1)
            {
                int colorStartIndex = text.IndexOf('[', index + 3);
                int colorEndIndex = text.IndexOf(']', colorStartIndex);
                if (colorStartIndex > -1 && colorEndIndex > -1)
                {
                    string colorValue = text.Substring(colorStartIndex + 1, (colorEndIndex - colorStartIndex) - 1);
                    Color color = Color.FromArgb(colorValue.ToInt());
                    text = text.Remove(index, 3);
                    newRenderOptions.RemoveRange(index, 3);
                    text = text.Remove(colorStartIndex - 3, colorValue.Length + 2);
                    newRenderOptions.RemoveRange(colorStartIndex - 3, colorValue.Length + 2);
                    int endIndex = text.IndexOf("[/c]");
                    if (endIndex > -1)
                    {
                        text = text.Remove(endIndex, 4);
                        newRenderOptions.RemoveRange(endIndex, 4);
                        for (int i = index; i < endIndex; i++)
                        {
                            newRenderOptions[i].ForeColor = color;
                        }
                    }
                }
                index = text.IndexOf("[c]");
            }

            return newRenderOptions.ToArray();
        }
    }
}
