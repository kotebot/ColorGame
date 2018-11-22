using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplamentaryColor : MonoBehaviour {

    public static void RgbToHls(int r, int g, int b, out double h, out double l, out double s)
    {
        // Convert RGB to a 0.0 to 1.0 range.
        double double_r = r / 255.0;
        double double_g = g / 255.0;
        double double_b = b / 255.0;

        // Get the maximum and minimum RGB components.
        double max = double_r;
        if (max < double_g) max = double_g;
        if (max < double_b) max = double_b;

        double min = double_r;
        if (min > double_g) min = double_g;
        if (min > double_b) min = double_b;

        double diff = max - min;
        l = (max + min) / 2;
        if (Mathf.Abs((float)diff) < 0.00001)
        {
            s = 0;
            h = 0;  // H is really undefined.
        }
        else
        {
            if (l <= 0.5) s = diff / (max + min);
            else s = diff / (2 - max - min);

            double r_dist = (max - double_r) / diff;
            double g_dist = (max - double_g) / diff;
            double b_dist = (max - double_b) / diff;

            if (double_r == max) h = b_dist - g_dist;
            else if (double_g == max) h = 2 + r_dist - b_dist;
            else h = 4 + g_dist - r_dist;

            h = h * 60;
            if (h < 0) h += 360;
        }
    }

    // Convert an HLS value into an RGB value.
    public static void HlsToRgb(double h, double l, double s, out int r, out int g, out int b)
    {
        double p2;
        if (l <= 0.5) p2 = l * (1 + s);
        else p2 = l + s - l * s;

        double p1 = 2 * l - p2;
        double double_r, double_g, double_b;
        if (s == 0)
        {
            double_r = l;
            double_g = l;
            double_b = l;
        }
        else
        {
            double_r = QqhToRgb(p1, p2, h + 120);
            double_g = QqhToRgb(p1, p2, h);
            double_b = QqhToRgb(p1, p2, h - 120);
        }

        // Convert RGB to the 0 to 255 range.
        r = (int)(double_r * 220.0) + Random.Range(-25, 25);
        g = (int)(double_g * 220.0) + Random.Range(-25, 25);
        b = (int)(double_b * 220.0) + Random.Range(-25, 25);
    }

    private static double QqhToRgb(double q1, double q2, double hue)
    {
        if (hue > 360) hue -= 360;
        else if (hue < 0) hue += 360;

        if (hue < 60) return q1 + (q2 - q1) * hue / 60;
        if (hue < 180) return q2;
        if (hue < 240) return q1 + (q2 - q1) * (240 - hue) / 60;
        return q1;
    }

    public static Color32 CompColor(Color32 input)
    {
        Color32 output = new Color32();

        double h=0, s=0, l=0, h2;
        int r=0, g=0, b=0;

        RgbToHls(input.r, input.g, input.b, out h,out s,out l);

        h2 = h + 0.5;

        if(h2>1)
            h2 -= 1;
        HlsToRgb(h2, l, s, out r, out g, out b);

        output.r = (byte)r;
        output.g = (byte)g;
        output.b = (byte)b;
        output.a = 255;


        return output;
    }

}
