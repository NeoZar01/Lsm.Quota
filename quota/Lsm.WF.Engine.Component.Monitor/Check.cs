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
    public class Check : OnMethodBoundaryAspect
    {

        protected DateTime _estimatedMinutes;
        protected string   _type;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listener"></param>
        /// <param name="estimatedExecutionTimeInMinutes"></param>
        public Check(string listener, int estimatedExecutionTimeInMinutes)
        {
                 _estimatedMinutes = DateTime.Now;
            this._estimatedMinutes = this._estimatedMinutes.AddMinutes(estimatedExecutionTimeInMinutes);
            this._type = listener;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        [InstanceEntityType(null, Name ="Time")]
        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = new PayloadContext {   InstanceId =  Guid.NewGuid() , Entity = _estimatedMinutes , SubEntity = DateTime.Now};
            base.OnEntry(args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public override void OnExit(MethodExecutionArgs args)
        {

           var finalExecutionTime = (PayloadContext)args.MethodExecutionTag;

            base.OnExit(args);
        }
    }
}
