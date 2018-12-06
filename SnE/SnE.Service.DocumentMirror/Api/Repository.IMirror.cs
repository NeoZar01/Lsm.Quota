using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnE.Component.DocumentsManager.Api
{
    using EF;
    using Api;

    public interface IMirrorRepository : IRepository<Mirror>
    {

      /// <summary>
      ///       Mirrors a new File and returns a response. 
      /// </summary>
      /// <param name="curator"></param>
      /// <param name="documentToken"></param>
      /// <param name="originalName"></param>
      /// <param name="extension"></param>
      /// <param name="bytes"></param>
      /// <param name="entityType"></param>
      /// <param name="interfaceKey"></param>
      /// <returns></returns>
      Task<string> MapMirror(string curator, string originalName, string extension, byte[] bytes, string entityType, string interfaceKey , string documentToken ); 
    }
}
