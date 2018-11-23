namespace DoE.Lsm.Context
{
    using System.Xml;
    using System.Xml.Serialization;

    ///<summary>
    ///      
    ///</summary>
    public static class XmlContext 
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static object Create<T>(object entity, string fileName, string filePath) where T : class
        {
            try
            {
                var settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.CloseOutput = true;

                var xml = new XmlSerializer(entity.GetType());

                using (var w = XmlWriter.Create(string.Concat(filePath, fileName, ".xml"), settings))
                {                        
                    xml.Serialize(w, entity);
                }

                return entity;

            }
            catch
            {
              throw;
            }
        }

    }

}
