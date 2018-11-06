using System;

using PostSharp.Aspects;
using PostSharp.Serialization;

namespace DoE.Lsm.WF.Component.Monitor.Annotations
{
    using Core;
    using Engine.Context;
    using Lsm.Annotations;
    using WI.Models;

    /// <summary>
    /// 
    /// </summary>
    [PSerializable]
    public class Trace : OnMethodBoundaryAspect
    {

        protected DateTime _estimatedMinutes;
        protected string   _type;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="estimate"></param>
        public Trace(string request, int estimate)
        {
                 _estimatedMinutes = DateTime.Now;
            this._estimatedMinutes = this._estimatedMinutes.AddMinutes(estimate);
            this._type = request;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        [InstanceType(entities: "Time")]
        public override void OnEntry(MethodExecutionArgs args)
        {
            // EntityType = _estimatedMinutes
            args.MethodExecutionTag = new WorkItemInstance {   WIToken =  Guid.NewGuid().ToString()  , SubEntity = DateTime.Now};
            base.OnEntry(args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public override void OnExit(MethodExecutionArgs args)
        {

           var finalExecutionTime = (WorkItemInstance)args.MethodExecutionTag;

            base.OnExit(args);
        }
    }
}
