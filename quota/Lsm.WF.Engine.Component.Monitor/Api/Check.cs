using System;

using PostSharp.Aspects;
using PostSharp.Serialization;

namespace DoE.Lsm.WF.Component.Monitor.Annotations
{
    using Engine.Context;
    using Lsm.Annotations;

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
        /// <param name="listener"></param>
        /// <param name="estimatedExecutionTimeInMinutes"></param>
        public Trace(string listener, int estimatedExecutionTimeInMinutes)
        {
                 _estimatedMinutes = DateTime.Now;
            this._estimatedMinutes = this._estimatedMinutes.AddMinutes(estimatedExecutionTimeInMinutes);
            this._type = listener;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        [InstanceType(entities: "Time")]
        public override void OnEntry(MethodExecutionArgs args)
        {
            // EntityType = _estimatedMinutes
            args.MethodExecutionTag = new ProcessWorkItem {   ProcessInstanceToken =  Guid.NewGuid().ToString()  , SubEntity = DateTime.Now};
            base.OnEntry(args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public override void OnExit(MethodExecutionArgs args)
        {

           var finalExecutionTime = (ProcessWorkItem)args.MethodExecutionTag;

            base.OnExit(args);
        }
    }
}
