using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.Security
{
    public  static class ProcessInstanceSecurityToken
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xpryDate"></param>
        /// <param name="processInstanceId"></param>
        /// <param name="claimsIdentity"></param>
        /// <returns></returns>
        public static string Create(DateTime xpryDate, string processInstanceId, string claimsIdentity) {

            byte[] xpr = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            byte[] claims = Guid.NewGuid().ToByteArray();

            byte[] data = new byte[xpr.Length + key.Length + claims.Length];

            Buffer.BlockCopy(xpr, 0, data, 0, xpr.Length);
            Buffer.BlockCopy(key, 0, data, xpr.Length, key.Length);
            Buffer.BlockCopy(claims, 0, data, xpr.Length + key.Length, claims.Length);

            string token = Convert.ToBase64String(data.ToArray());

            return token;
        }
    }
}
