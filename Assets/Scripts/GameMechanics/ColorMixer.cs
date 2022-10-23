using System;
using System.Collections.Generic;
using UnityEngine;

public class ColorMixer 
{
    public Color GetMixedColor(List<Color> colors)
    {
        var color = new Color(0,0,0,0);

        foreach (var colorValue in colors)
        {
            color += colorValue;
        }

        color = color / colors.Count;

        color = new Color(color.r,color.g,color.b,color.a*colors.Count);

        return color;
    }

    public double GetSimilarityPercentageColor(Color32 color1, Color32 color2)
    {
        int diffRed   = Math.Abs(color1.r   - color2.r);
        int diffGreen = Math.Abs(color1.g - color2.g);
        int diffBlue  = Math.Abs(color1.b  - color2.b);
        
        float pctDiffRed   = (float)diffRed   / 255;
        float pctDiffGreen = (float)diffGreen / 255;
        float pctDiffBlue   = (float)diffBlue  / 255;

        var p = (pctDiffRed + pctDiffGreen + pctDiffBlue) / 3 * 100;

        return 100-p;
    }

}
