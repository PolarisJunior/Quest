using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGenerator
{
    static Color[] namedColors = { Color.red, Color.blue, Color.green, Color.yellow, Color.cyan };

    public static Color GenerateColor() {
        Color[] colors = GenerateColors(1);
        return colors[0];
    }

    public static Color[] GenerateColorsHsv(int n)
    {
        Color[] colors = new Color[n];
        Color namedColor = RandomNamedColor();
        float h, s, v;
        Color.RGBToHSV(namedColor, out h, out s, out v);
        Debug.Log(h);

        float seed = Random.Range(0f, 1000f);
        for (var i = 0; i < n; i++)
        {
            // float hue = Random.Range(0f, 1f);
            float hue = Mathf.PerlinNoise(seed + i, seed + i);

            float saturation = Random.Range(.6f, 1f);

            float value = Random.Range(.5f, 1f);

            if (true)
            {
                hue = (hue + h) / 2;
                saturation = (saturation + s) / 2;
                v = (value + v) / 2;
            }

            colors[i] = Color.HSVToRGB(hue, saturation, value);
        }

        return colors;
    }

    public static Color RandomNamedColor()
    {
        return namedColors[Random.Range(0, namedColors.Length)];
    }


    public static Color[] GenerateColors(int n)
    {
        Color[] colors = new Color[n];
        for (var i = 0; i < colors.Length; i++)
        {
            colors[i] = Color.black;
        }

        Color namedColor = RandomNamedColor();

        // generate component by component
        for (var comp = 0; comp < 3; comp++)
        {
            // use same time value for components
            float seed = Random.Range(0f, 1000f);

            for (var i = 0; i < n; i++)
            {
                float v = Mathf.PerlinNoise(seed + i, seed + i);
                // tend towards brighter colors
                // v = (1 + v) / 2;
                // colors[i][comp] = v;
                colors[i][comp] = (v + namedColor[comp]) / 2;
            }
        }

        return colors;
    }

}
