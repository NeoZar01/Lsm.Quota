using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnE.Component.DocumentsManager.Controllers
{
    using Api;

    public class ImageResizeWorker
    {
        public string status;

        public delegate string ResizeImageCallBack(string sourcePath, string destinationPath, int width, int heighth);

        public ResizeImageCallBack ImageSizeProperties;

        public void ResizeImage(DocumentMirrorCallbacksContainer callback, string sourcePath, string destinationPath, int width, int height)
        {
            ImageSizeProperties = callback.ResizeImageCallBack;
            status = ImageSizeProperties(sourcePath, destinationPath,  width, height);
        }
    }
}
