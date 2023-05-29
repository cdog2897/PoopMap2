using System;
using Microsoft.Maui.Controls;
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

        public static async Task<string> ConvertImageSourceToBase64(ImageSource image)
        {
            Stream stream = await ((StreamImageSource)image).Stream(CancellationToken.None);
            byte[] bytesAvailable = new byte[stream.Length];
            stream.Read(bytesAvailable, 0, bytesAvailable.Length);

            return Convert.ToBase64String(bytesAvailable);
        }

        public static ImageSource ConvertBase64ToImageSource(string base64pic)
        {
            byte[] bytes = Convert.FromBase64String(base64pic);
            ImageSource imageSource = ImageSource.FromStream(() => new MemoryStream(bytes));
            return imageSource;
        }
    }
}

