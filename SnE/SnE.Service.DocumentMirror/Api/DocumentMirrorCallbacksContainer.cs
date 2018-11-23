using System;
using System.Drawing;

namespace SnE.Component.DocumentsManager.Api
{

    using EF;
    using Repositories;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Threading.Tasks;

    public class DocumentMirrorCallbacksContainer : IDocumentMirrorCallbacksContainer
    {

        protected readonly IRepositoryStoreManager _repositoryManager;

        public DocumentMirrorCallbacksContainer(IRepositoryStoreManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }

        public string ResizeImageCallBack(string sourcePath, string destinationPath, int width, int height)
        {
            if (File.Exists(sourcePath))
            return "FAILED";

            try
            {                

                Bitmap resizedImage = new Bitmap(width, height);
                Graphics g = Graphics.FromImage((Image)resizedImage);
                g.InterpolationMode = InterpolationMode.High;
                g.DrawImage(Image.FromFile(sourcePath), 0, 0, width, height);
                resizedImage.Save(destinationPath, ImageFormat.Jpeg);
                return "SUCCESSFUL";
            }
            catch
            {
                return "FAILED";
            }
        }


        public async Task<string> MapMirror(string curator, string documentToken, string originalName, string extension, byte[] bytes, string entityType, string interfaceKey)
        {
            return await _repositoryManager.MirrorStore.MapMirror( curator , documentToken, originalName, extension, bytes, entityType, interfaceKey);
        }

    }
}
