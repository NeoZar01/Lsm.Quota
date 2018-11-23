using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnE.Component.DocumentsManager.Api
{
    using Repositories;
    using System.Drawing;

    public interface IDocumentMirrorCallbacksContainer
    {

        /// <summary>
        ///     Archives the file into a database
        /// </summary>
        /// <param name="sourceImage"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="newSaveLocation"></param>
        /// <returns></returns>
        Task<string> MapMirror(string curator, string documentToken, string originalName, string extension, byte[] bytes, string entityType, string interfaceKey);

        /// <summary>
        ///     Resized an image and copies it to a new location using the alloted token.
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destinationPath"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        string ResizeImageCallBack(string sourcePath, string destinationPath, int width, int height);
    }
}
