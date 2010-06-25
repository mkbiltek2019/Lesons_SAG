using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace DrawingCanvas.ImageManger
{
    public static class FileExtension
    {
        public static readonly string[] fileExtensions = new string[] { " tiff files (*.tiff)|*.tiff|",
                                                                        " png files (*.png)|*.png|",
                                                                        " gif files (*.gif)|*.gif|",
                                                                        " jpg files (*.jpg)|*.jpg|",
                                                                        " bmp files (*.bmp)|*.bmp|",
                                                                        " All files (*.*)|*.*"};
        public enum fileExt
        {
            Tif = 1,
            Png = 2,
            Gif = 3,
            Jpg = 4,
            Bmp = 5
        };

        public static readonly string JpgMimeType = "image/jpeg";
        public static readonly string TiffMimeType = "image/tiff";
        public static readonly string GifMimeType = "image/gif";
        public static readonly string BmpMimeType = "image/bmp";
        public static readonly string PngMimeType = "image/png";
    }

    public class SaveFileDialogWrapper
    {
        private int filterIndex;

        public int FilterIndex
        {
            get
            {
                return filterIndex;
            }
        }

        public string Save()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            string extension = string.Empty;

            for (int i = 0; i < FileExtension.fileExtensions.Length; i++)
            {
                extension += FileExtension.fileExtensions[i];
            }

            saveFileDialog.Filter = extension;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filterIndex = saveFileDialog.FilterIndex;
                return saveFileDialog.FileName;
            }

            return string.Empty;
        }
    }

    public class ImageManager
    {
        private string fileName;
        private string fullFileName;

        public int imageQuality = 0;

        public string FileName
        {
            get
            {
                return fileName;
            }
        }

        public string FullFileName
        {
            get
            {
                return fullFileName;
            }
        }

        public Bitmap Open()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = @"All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = false;

            Bitmap loadedImage = null;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    loadedImage = (Bitmap)Image.FromFile(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    loadedImage = null;
                }

                if (loadedImage != null)
                {
                    fileName = openFileDialog.SafeFileName;
                    fullFileName = openFileDialog.FileName;
                    return loadedImage;
                }
            }

            return loadedImage;
        }

        public void Save(string fullName, Bitmap curentImage)
        {
            SaveFileDialogWrapper saveDialog = new SaveFileDialogWrapper();
            string fileName = saveDialog.Save();

            if (fileName != null)
            {
                switch ((FileExtension.fileExt)saveDialog.FilterIndex)
                {
                    case FileExtension.fileExt.Bmp:
                        {
                            SaveBitmapByExtension(fileName, fullName, curentImage, FileExtension.BmpMimeType);
                        }
                        break;
                    case FileExtension.fileExt.Gif:
                        {
                            SaveBitmapByExtension(fileName, fullName, curentImage, FileExtension.GifMimeType);
                        }
                        break;
                    case FileExtension.fileExt.Jpg:
                        {
                            SaveBitmapByExtension(fileName, fullName, curentImage, FileExtension.JpgMimeType);
                        }
                        break;
                    case FileExtension.fileExt.Png:
                        {
                            SaveBitmapByExtension(fileName, fullName, curentImage, FileExtension.PngMimeType);
                        }
                        break;
                    case FileExtension.fileExt.Tif:
                        {
                            SaveBitmapByExtension(fileName, fullName, curentImage, FileExtension.TiffMimeType);
                        }
                        break;
                }
            }

        }

        private void SaveBitmapByExtension(string fileDialogName, string fullName, Bitmap curentImage, string encoderInfo)
        {
            if (fullName == null)
            {
                SaveImage(fileDialogName, curentImage, imageQuality, encoderInfo);
            }
            else
            {
                SaveImage(fullName, curentImage, imageQuality, encoderInfo);
            }
        }

        private void SaveImage(string path, Image image, long quality, string encoderInfo)
        {
            // Encoder parameter for image quality
            EncoderParameter qualityParam = 
                new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

            // image codec
            ImageCodecInfo codec = GetEncoderInfo(encoderInfo);

            if (codec == null)
                return;

            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            
            image.Save(path, codec, encoderParams);
            
        }


        private ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }
    }
}
