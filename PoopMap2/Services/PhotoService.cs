using System;
using Microsoft.Maui.Graphics.Platform;
using IImage = Microsoft.Maui.Graphics.IImage;

namespace PoopMap2.Services
{
	public static class PhotoService
	{

        public async static Task<IImage> FormatImage(FileResult photo)
        {

            Stream stream = await photo.OpenReadAsync();
            IImage image = PlatformImage.FromStream(stream);
            return image;
        }

        public async static Task<byte[]> ConvertImageToBytes(FileResult photo)
        {

            byte[] imageData;

            Stream fileStream = await photo.OpenReadAsync();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                await fileStream.CopyToAsync(memoryStream);
                imageData = memoryStream.ToArray();
            }

            return imageData;
        }

        public static ImageSource ConvertBytesToImage(byte[] bytes)
        {
            ImageSource imageSource = ImageSource.FromStream(() => new MemoryStream(bytes));
            return imageSource;
        }
    }
}

