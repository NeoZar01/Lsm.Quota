using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DoE.Lsm.Web.Models
{

    using Annotations;
    using Data.Repositories;
    using static DoE.Web.Mvc.Api.RoleType;
    /// <summary>
    ///     
    /// </summary>
    [InstanceType(nameof(School), "School")]
    public partial class SchoolDashboardViewModel : DashboardFactoryViewModel
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public override async Task<DashboardFactoryViewModel> Return(string instanceId, IRepositoryStoreManager dataSource)
        {        
            return await Task.FromResult( new SchoolDashboardViewModel {
                        Page     = "_mainpagedashboard_school"
            });
        }
    }

    /// <summary>
    ///     
    /// </summary>
    [InstanceType(nameof(CircuitManager) , "CircuitManager")]
    public partial class CircuitDashboardViewModel : DashboardFactoryViewModel
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public override async Task<DashboardFactoryViewModel> Return(string instanceId, IRepositoryStoreManager dataSource)
        {
            return await Task.FromResult(new CircuitDashboardViewModel
            {
            });
        }
    }

    /// <summary>
    ///     
    /// </summary>
    [InstanceType(nameof(Administrator), "Administrator")]
    public partial class AdministratorDashboardViewModel : DashboardFactoryViewModel
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public override async Task<DashboardFactoryViewModel> Return(string instanceId, IRepositoryStoreManager dataSource)
        {
            return await Task.FromResult(new AdministratorDashboardViewModel
            {   Page     = "_mainpagedashboard_administrator"
            });
        }
    }

    public abstract class DashboardFactoryViewModel
    {
        public DashboardFactoryViewModel()
        {}

        public virtual async Task<DashboardFactoryViewModel> Return(string instanceId, IRepositoryStoreManager repositoryStore)
        {return await Task.FromResult(this);}


        /// <summary>
        /// 
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BookYear { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SubmittedRequisitions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SubmissionTotalPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int InDrafts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int DraftsTotalPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Rejects { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int RejectsTotalPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Approved { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ApprovedTotalPrice { get; set; }

    }

    public class WebSearchViewModel
    {}
}