﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

using PagedList;

namespace DoE.Lsm.Data.Repositories.Persons
{
    using EF;
    using Logger;
    using Annotations.Exceptions;

    public class IdentityAuthRepository : RepositoryFactory<Person> , IIdentityAuth
    {

        private Guid _globalUserId;

        public IdentityAuthRepository(DbContext context, ILogger logger) : base(context, logger){}

        public IEnumerable<int> GetEmisCodesByPerson(string keyword)
        {
            var codes =  (from p in DataContainer.People
                      where p.FirstName.Contains(keyword) || p.LastName.Contains(keyword) || p.MaidenName.Contains(keyword)
                     select   new { p.EmisCode })
                     .Take(5);

            foreach(var person in codes)
            {
                yield return person.EmisCode;
            }

        }

        public IEnumerable<vwPersonalDetail> GetPersonByKey(string keyword)
        {
            var query = DataContainer.vwPersonalDetails
                         .Where(c => c.FirstName.Contains(keyword) || c.LastName.Contains(keyword) || c.MaidenName.Contains(keyword));
            
            foreach(var person in query)
            {
                    yield return person;
            }                  
                               
        }

        public IPagedList<vwPersonalDetail> GetPersonByKey(string keyword, int? page)
        {

            var pageSize = 15;
            var pageNumber = (page ?? 1);
            var emisCode = 0;

            try
            {
                emisCode = int.Parse(keyword);
            }
            catch
            {
                emisCode = 0; 
            }


            var query = DataContainer.vwPersonalDetails
                                   .Where(c => c.FirstName.Contains(keyword) || c.LastName.Contains(keyword) || c.MaidenName.Contains(keyword) || c.EmisCode == emisCode)
                                   .OrderBy( c => c.FirstName);

            return query.ToPagedList<vwPersonalDetail>(pageNumber, pageSize);
        }

        public vwPersonalDetail GetPerson(int id)
        {
            try
            {
                 var account =  DataContainer.vwPersonalDetails
                               .Where( c=> c.EmisCode == id)
                               .SingleOrDefault();
                return account;
            }
            catch
            {
                throw new InvalidDatabaseOperationException();
            }
        }

        public Person GetPersonDetails(int id)
        {

            try
            {
                var personalDetailsQuery = DataContainer.People
                              .Where(c => c.EmisCode == id)
                              .SingleOrDefault();
                return personalDetailsQuery;
            }
            catch
            {
                throw new InvalidDatabaseOperationException();
            }
        }

        public Address GetAddressDetails(int emisCode)
        {
            throw new NotImplementedException();
        }

        public vwAddressDetail GetWorkDetails(int emisCode)
        {
            try
            {

            var query = DataContainer.vwAddressDetails
                .Where(c => c.EmisCode == emisCode)
                .SingleOrDefault();

                return query as vwAddressDetail;
            }
            catch
            {
                throw new InvalidDatabaseOperationException();
            }

        }

        public vwPositionDetail GetPositionDetails(int emisCode)
        {
             try
            {
                var positionQuery = DataContainer.vwPositionDetails
                                        .Where(c => c.EmisCode == emisCode)
                                        .SingleOrDefault();
                return positionQuery;
            }
            catch
            {
                throw new InvalidDatabaseOperationException();
            }
        }

        public vwAccountSetting GetAccountSettings(int emisCode)
        {
            try
            {
                var settingsQuery = DataContainer.vwAccountSettings
                                        .Where(c => c.EmisCode == emisCode)
                                        .SingleOrDefault();
                return settingsQuery;
            }
            catch
            {
                throw new InvalidDatabaseOperationException();
            }
        }

        public Contact GetContactDetails(int emisCode)
        {
            try
            {
                var contactdQuery = DataContainer.Contacts
                                        .Where(c => c.EmisCode == emisCode)
                                        .SingleOrDefault();
                return contactdQuery;
            }
            catch
            {
                throw new InvalidDatabaseOperationException();
            }
        }

        public  async Task<Contact> GetContactDetailsAsync(int emisCode)
        {
            try
            {
                var contactdQuery = await DataContainer.Contacts
                                        .Where(c => c.EmisCode == emisCode)
                                        .SingleOrDefaultAsync();
                return contactdQuery;
            }
            catch
            {
                throw new InvalidDatabaseOperationException();
            }
        }

        public string GetEmail(int emisCode)
        {
            try
            {
                var emailQuery = DataContainer.vwAccountSettings
                              .Where(c => c.EmisCode == emisCode)
                              .SingleOrDefault();
                return emailQuery.Email;
            }
            catch
            {
                throw new InvalidDatabaseOperationException();
            }
        }

        public async Task<string> GetEmailAsync(int emisCode)
        {
            try
            {
                var emailQuery = await DataContainer.vwAccountSettings
                              .Where(c => c.EmisCode == emisCode)
                              .SingleOrDefaultAsync();
                return emailQuery.Email;
            }
            catch
            {
                throw new InvalidDatabaseOperationException();
            }
        }

        public async Task<vwPersonalDetail> GetPersonAsync(int id)
        {
            try
            {
                var account = await DataContainer.vwPersonalDetails
                              .Where(c => c.EmisCode == id)
                              .SingleOrDefaultAsync();
                return account;
            }
            catch
            {
                throw new InvalidDatabaseOperationException();
            }
        }

        public async Task<vwAccountSetting> GetAccountSettingsAsync(int emisCode)
        {
            try
            {
                var settingsQuery = await DataContainer.vwAccountSettings
                                        .Where(c => c.EmisCode == emisCode)
                                        .SingleOrDefaultAsync();
                return settingsQuery;
            }
            catch
            {
                throw new InvalidDatabaseOperationException();
            }
        }


        public PortalAuth DataContainer { get { return this._DbContext as PortalAuth; } }

        public Guid GlobalId
        {
            get
            {
                return string.IsNullOrEmpty(_globalUserId.ToString()) ? new Guid("invalid UserId") : _globalUserId;
            }

            set
            {
                int emisCode = int.Parse(value.ToString());

                _globalUserId = DataContainer.People.Where(c => c.EmisCode == emisCode).SingleOrDefault().RowGuid;  
            }
        }
    }
}
