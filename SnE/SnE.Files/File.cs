using System;
using DoE.Lsm.Context;
using Microsoft.SqlServer.Server;

using Format = DoE.Lsm.Files.Formats.Abstracts;
using Newtonsoft.Json;

namespace DoE.Lsm.UoW
{
    /// <summary>
    ///     
    /// </summary>
    public static class File
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="path"></param>
        /// <param name="format"></param>
        public static void WriteInto<T>(T entity, string fileName, string filePath, Format::Format format) where T : class
        {
            try
            {

            switch(format)
            {
                case Format::Format.Xml:
                        XmlContext.Create<T>(entity, fileName, filePath);
                break;                               
            }
            }catch
            {
                throw;
            }
        }
    }
}