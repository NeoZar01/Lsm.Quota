using System;

namespace DoE.Lsm.Services.Api
{
    using Logger;
    using DefaultShoppingCardNS = ShoppingCard.Api;
    /// <summary>
    /// 
    /// </summary>
    public class Caller : IServicesFactory
    {

        /// <summary>
        ///         constructor
        /// </summary>
        /// <param name="logger"></param>
        public Caller(ILogger logger, DefaultShoppingCardNS::IShoppingCard shoppingcard)
        {

            //newup the EventLogger from the container
            Logger       = logger;

            //newup the shoppingcard from the container
            ShoppingCard = shoppingcard;

        }

        public ILogger Logger
        { get; set; }

        public DefaultShoppingCardNS::IShoppingCard ShoppingCard
        { get; set; }
    }

}
