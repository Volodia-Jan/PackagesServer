using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using ZXing;
using ZXing.Common;

namespace PackagesServer.Core.Helpers;
public static class BarecodeGenerator
{
    public static byte[] GenerateBarcode(string text)
    {
        var writer = new BarcodeWriterPixelData
        {
            Format = BarcodeFormat.CODE_128,
            Options = new EncodingOptions
            {
                Height = 200,
                Width = 600
            }
        };

        var pixelData = writer.Write(text);

#pragma warning disable CA1416 // Validate platform compatibility
        using var bitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb);
        BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);
        try
        {
            Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
        }
        finally
        {
            bitmap.UnlockBits(bitmapData);
        }
        using (var graphics = Graphics.FromImage(bitmap))
        {
            // Встановлюємо розмір шрифту та колір тексту
            var font = new Font(FontFamily.GenericSansSerif, 12);
            var brush = new SolidBrush(Color.Black);

            // Розміщуємо текст на зображенні
            var textPosition = new PointF(10, 10); // Встановлюємо позицію тексту
            graphics.DrawString(text, font, brush, textPosition);
        }
        using var stream = new MemoryStream();
        bitmap.Save(stream, ImageFormat.Jpeg);
#pragma warning restore CA1416 // Validate platform compatibility
        return stream.ToArray();
    }
}
