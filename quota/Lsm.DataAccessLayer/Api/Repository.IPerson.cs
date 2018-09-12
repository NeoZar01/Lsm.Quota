using System.Collections.Generic;
using System.Threading.Tasks;
using PagedList;
using System;
using DoE.Lsm.Data.Repositories.EF;

namespace DoE.Lsm.Data.Repositories.Persons
{

    public interface IPersonRepository : IRepository<Person>
    {

        Guid GlobalId { get; set; }

        #region    ************* Scalar Functions

        string GetEmail(int emisCode);

        Task<string> GetEmailAsync(int emisCode);
        #endregion

        #region    **************** table-Valued Functions

            IEnumerable<int> GetEmisCodesByPerson(string keyword);

            Person GetPersonDetails(int id);

            Address GetAddressDetails(int emisCode);

            Contact GetContactDetails(int emisCode);

            Task<Contact> GetContactDetailsAsync(int emisCode);

        #region    ***************** Categered for Views Views

            Task<vwPersonalDetail> GetPersonAsync(int id);

            IEnumerable<vwPersonalDetail> GetPersonByKey(string keyword);

            IPagedList<vwPersonalDetail> GetPersonByKey(string keyword, int? page);

            vwAddressDetail GetWorkDetails(int emisCode);

            vwPersonalDetail GetPerson(int id);

            vwPositionDetail GetPositionDetails(int emisCode);


            vwAccountSetting GetAccountSettings(int emisCode);

            Task<vwAccountSetting> GetAccountSettingsAsync(int emisCode);
        #endregion


        #endregion


    }
}
