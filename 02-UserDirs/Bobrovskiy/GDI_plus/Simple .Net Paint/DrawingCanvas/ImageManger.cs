using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace DrawingCanvas.ImageManger
{
    public class FileExtensionItem
    {
        public string FileExtensionForFilter
        {
            get;
            set;
        }

        public ImageFormat FileFormat
        {
            get;
            set;
        }

    }

    public static class FileExtension
    {
        private static ArrayList CreateExtensionList()
        {
            ArrayList result = new ArrayList();

            result.Add(new FileExtensionItem()
            {
                FileExtensionForFilter = " tiff files (*.tiff)|*.tiff|",
                FileFormat = ImageFormat.Tiff
            });

            result.Add(new FileExtensionItem()
            {
                FileExtensionForFilter = " png files (*.png)|*.png|",
                FileFormat = ImageFormat.Tiff
            });

            result.Add(new FileExtensionItem()
            {
                FileExtensionForFilter = " gif files (*.gif)|*.gif|",
                FileFormat = ImageFormat.Tiff
            });

            result.Add(new FileExtensionItem()
            {
                FileExtensionForFilter = " jpg files (*.jpg)|*.jpg|",
                FileFormat = ImageFormat.Tiff
            });

            result.Add(new FileExtensionItem()
            {
                FileExtensionForFilter = " bmp files (*.bmp)|*.bmp|",
                FileFormat = ImageFormat.Tiff
            });

            result.Add(new FileExtensionItem()
            {
                FileExtensionForFilter = " All files (*.*)|*.*",
                FileFormat = ImageFormat.Tiff
            });

            return result;
        }

        public static string GetExtentionString()
        {
            string result = string.Empty;
            ArrayList arrayList = CreateExtensionList();

            for (int i = 0; i < arrayList.Count; i++)
            {
                result += (arrayList[i] as FileExtensionItem).FileExtensionForFilter;
            }

            return result;
        }

        public static ImageFormat GetImageFormatByFilterIndex(int filterIndex)
        {
            ArrayList arrayList = CreateExtensionList();
            if ((arrayList.Count > 0) && (filterIndex >= 0) && (filterIndex <= arrayList.Count))
            {
                return (arrayList[filterIndex] as FileExtensionItem).FileFormat;
            }
            return ImageFormat.Bmp;
        }
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

            saveFileDialog.Filter = FileExtension.GetExtentionString();

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
        public readonly long imageQuality = 100L;
        private string fileName;
        private string fullFileName;

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

        public Image Open()
        {
            Image loadedImage = null;
            Bitmap loadedImageCopy = null;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = FileExtension.GetExtentionString();
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        loadedImage = Image.FromFile(openFileDialog.FileName);
                        loadedImageCopy = ExtractBitmapFromOpenedFile(loadedImage);

                        fileName = openFileDialog.SafeFileName;
                        fullFileName = openFileDialog.FileName;

                        loadedImage.Dispose(); //image unlock !!!!!!!!!
                    }
                    catch (Exception ex)
                    {
                    }

                }
            }

            return loadedImageCopy;
        }

        public void Save(Image curentImage)
        {
            SaveFileDialogWrapper saveDialog = new SaveFileDialogWrapper();
            string fileName = saveDialog.Save();

            if (!string.IsNullOrEmpty(fileName))
            {
                SaveBitmapByExtension(fileName,
                                 curentImage,
                                 FileExtension.GetImageFormatByFilterIndex(saveDialog.FilterIndex));
            }
        }

        private void SaveBitmapByExtension(string fullFileName, Image curentImage, ImageFormat imageFormat)
        {
            if (!string.IsNullOrEmpty(fullFileName))
            {
                Bitmap bitmapToSave = ExtractBitmapFromOpenedFile(curentImage);

                EncoderParameters encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] =
                    new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, imageQuality);
                bitmapToSave.Save(fullFileName, GetEncoder(imageFormat), encoderParameters);

                bitmapToSave.Dispose();
            }
        }

        private Bitmap ExtractBitmapFromOpenedFile(Image curentImage)
        {
            Bitmap bitmapToSave = new Bitmap(curentImage.Width, curentImage.Height, PixelFormat.Format24bppRgb);
            bitmapToSave.SetResolution(curentImage.Width, curentImage.Height);

            using (Graphics graphics = Graphics.FromImage(bitmapToSave))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.DrawImage(curentImage,
                                   new Rectangle(0, 0, curentImage.Width, curentImage.Height),
                                   0, 0, curentImage.Width, curentImage.Height,
                                   GraphicsUnit.Pixel);
            }
            return bitmapToSave;
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

    }
}
