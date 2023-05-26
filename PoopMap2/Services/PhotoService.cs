using System;

namespace PoopMap2.Services
{
	public static class PhotoService
	{

        public static byte[] ConvertImageToBytes(string filePath, FileResult photo)
        {

            // save the file into local storage
            //using Stream sourceStream = await photo.OpenReadAsync();
            //using FileStream localFileStream = File.OpenWrite(filePath);
            //await sourceStream.CopyToAsync(localFileStream);


            byte[] imageData;

            // Open the image file stream
            using (FileStream fileStream = File.OpenRead(filePath))
            {
                // Read the image data into a byte array
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    fileStream.CopyTo(memoryStream);
                    imageData = memoryStream.ToArray();
                }
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

