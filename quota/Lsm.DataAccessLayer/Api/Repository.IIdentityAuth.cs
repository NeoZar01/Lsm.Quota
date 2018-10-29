using System.Collections.Generic;
using System.Threading.Tasks;
using PagedList;
using System;
using DoE.Lsm.Data.Repositories.EF;

namespace DoE.Lsm.Data.Repositories.Persons
{

    public interface IIdentityAuth : IRepository<Person>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        IEnumerable<int> GetEmisCodesByPerson(string keyword);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Person GetPersonDetails(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emisCode"></param>
        /// <returns></returns>
        Address GetAddressDetails(int emisCode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emisCode"></param>
        /// <returns></returns>
        Contact GetContactDetails(int emisCode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emisCode"></param>
        /// <returns></returns>
        Task<Contact> GetContactDetailsAsync(int emisCode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<vwPersonalDetail> GetPersonAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        IEnumerable<vwPersonalDetail> GetPersonByKey(string keyword);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        IPagedList<vwPersonalDetail> GetPersonByKey(string keyword, int? page);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emisCode"></param>
        /// <returns></returns>
        vwAddressDetail GetWorkDetails(int emisCode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        vwPersonalDetail GetPerson(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emisCode"></param>
        /// <returns></returns>
        vwPositionDetail GetPositionDetails(int emisCode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emisCode"></param>
        /// <returns></returns>
        Task<vwAccountSetting> GetAccountSettingsAsync(int emisCode);
    }
}
