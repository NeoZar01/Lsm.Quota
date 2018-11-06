using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoE.Lsm.WF.WI.Models
{

    ///<summary>
    ///     This will be the envelop that wraps all the requests to the Workflow engine. 
    ///  <remark> Similar to <c>HttpContext</c> </remark>
    /// </summary>
    public class WorkItemInstance
    {
        /// <summary>
        ///     Initial Instance Id of the EntityType thrown
        /// </summary>
        [Key]
        public string WIToken
        { get; set; }

        /// <summary>
        ///     Initial Instance Id of the EntityType thrown
        /// </summary>
        [Required]
        public string InstanceEntityType
        { get; set; }

        /// <summary>
        ///         Any Entity type passed with the payload
        /// </summary>
        public string ProcessInstanceId
        { get; set; }

        [Required]
        [DefaultValue("Async")]
        public string RequestType
        { get; set; }

        public string param_001 { get; set; }

        public string param_002 { get; set; }

        public string param_003 { get; set; }

        public string param_004 { get; set; }

        public string param_005 { get; set; }

        public string param_006 { get; set; }

        public string param_007 { get; set; }

        public string param_008 { get; set; }

        public string param_009 { get; set; }

        public string param_0010 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Status
        { get; set; }


        /// <summary>
        ///         Assigned Role
        /// </summary>
        public string Role
        { get; set; }

        /// <summary>
        ///         Used for routing
        /// </summary>
        public string Route
        { get; set; }

        /// <summary>
        ///         GEID of sender
        /// </summary>
        public string IdentityToken
        { get; set; }

        /// <summary>
        ///         Name of sender
        /// </summary>
        public string User
        { get; set; }

        /// <summary>
        ///         Payload receiver
        /// </summary>
        public string DestinationUser
        { get; set; }

        /// <summary>
        ///         Receiver name
        /// </summary>
        public string ReceiverName
        { get; set; }


        /// <summary>
        ///         SubEntity inheriting from the above entity
        /// </summary>
        public object SubEntity
        { get; set; }

    }

}