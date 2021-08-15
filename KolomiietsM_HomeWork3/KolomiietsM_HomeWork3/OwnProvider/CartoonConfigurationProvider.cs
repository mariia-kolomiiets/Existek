using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;

namespace KolomiietsM_HomeWork3.OwnProvider
{
    public class CartoonConfigurationProvider : ConfigurationProvider
    {
        public string PathCartoon { get; set; }
        public CartoonConfigurationProvider(string pathCartoon)
        {
            PathCartoon = pathCartoon;
        }
        public override void Load()
        {
            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            Bitmap myBitmap = new Bitmap("cartoon.jpg");
            Color pixelColor = myBitmap.GetPixel(50, 50);
            string key = "pix";
            string value = pixelColor.Name;
            data.Add(key, value);
            Data = data;
        }
    }
}
