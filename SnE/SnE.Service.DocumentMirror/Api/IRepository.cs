/*
 // This class will create signatures for all the mandatory methods that needs to be implemented in every repository class.

///<summary>
///  This class will create signatures for all the mandatory methods that needs to be implemented in every repository class.
///  <remark    cref=""> TEntity Represents a table for a particular type in the underlying database </remark>
///  <see       cref="https://msdn.microsoft.com/en-us/library/bb358844(v=vs.110).aspx#Inheritance%20Hierarchy"> For more info on using <Table> object </see>
///  <seealso   cref="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/where-generic-type-constraint"> For more info about setting constraints on generics implementations.</seealso>
///</summary>
*/

namespace SnE.Component.DocumentsManager.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepository<TEntity> where TEntity : class  //only class types can be passed as 
    {

        TEntity Single(int id);

        Task<TEntity> SingleAsync(int id);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        ///<summary>
        ///   Adds a new row to your table
        ///</summary
        void Push(TEntity entity);

        ///<summary>
        /// Adds a range of values to your table 
        ///</summary
        void PushRange(IEnumerable<TEntity> entities);

        ///<summary>
        ///  Searches your tables by passing an lambda expression
        ///  <return name="IEnumerable<TEntity>"> IEnumerable<TEntity> of results se based on the condition build by the passed expression </return>
        /// <param name="Expression<Funct<TEntity,bool>>"> Lamdba expression</param>
        ///</summary
        IEnumerable<TEntity> Many(Expression<Func<TEntity, bool>> predicate);

        // Searches your tables by passing an lambda expression
        ///<summary>
        ///  Searches your tables by passing an lambda expression
        ///  <return name="IEnumerable<TEntity>"> IEnumerable<TEntity> of results se based on the condition build by the passed expression </return>
        /// <param name="Expression<Funct<TEntity,bool>>"> Lamdba expression</param>
        ///</summary
        IEnumerable<TEntity> ManyAsync(Expression<Func<TEntity, bool>> predicate);
    }
    
}
