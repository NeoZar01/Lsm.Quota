﻿using System;

using PostSharp.Aspects;
using PostSharp.Serialization;

namespace DoE.Lsm.WF.Component.Monitor.Annotations
{
    using Core;
    using Lsm.Annotations;
    using Service.WI.Proxies;

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
            args.MethodExecutionTag = new TokenProvisionerModelProxy {   SecurityToken =  Guid.NewGuid().ToString()};
            base.OnEntry(args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public override void OnExit(MethodExecutionArgs args)
        {

           var finalExecutionTime = (TokenProvisionerModelProxy)args.MethodExecutionTag;

            base.OnExit(args);
        }
    }
}
