using System.Drawing;

namespace Minecraft1_8_9Port.net.minecraft.client.renderer.texture;

public class TextureUtil
{
    public static Bitmap readBufferedImage(Stream imageStream)
    {
        if (imageStream == null)
        {
            return null;
        }

        Bitmap bitmap = null;

        try
        {
            bitmap = new Bitmap(imageStream);
        }
        finally
        {
            imageStream?.Dispose(); // Close the stream if it's not null
        }

        return bitmap;
    }
}