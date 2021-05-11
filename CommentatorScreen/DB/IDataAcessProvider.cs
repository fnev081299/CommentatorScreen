using System.Collections.Generic;

namespace CommentatorScreen
{
    public interface IDataAcessProvider
    {
        /// <summary>
        /// Get the runlog from the database
        /// </summary>
        /// <returns>Rn_runlog as a list</returns>
        List<RnRunlog> GetRunlog();

        /// <summary>
        /// Get category from db using the id
        /// </summary>
        /// <param name="id">Id of the desired category</param>
        RnCateg GetCategory(int id);

        /// <summary>
        /// Get the current active catgory from the DB
        /// </summary>
        RnCateg GetCurrentCategory();

        /// <summary>
        /// Get the current active catgories ID from the DB
        /// </summary>
        /// <returns>The id of the current category</returns>
        int GetCurrentCategoryId();

        /// <summary>
        /// Get the current qualifying for a category
        /// </summary>
        /// <param name="id">Id of the category</param>
        /// <returns>Rn qual as a list</returns>
        public List<QualifyingRun> GetCurrentQualifying(int id);

        /// <summary>
        /// Get all incremental information from the prediction model
        /// </summary>
        /// <returns>incremental information</returns>
        public CnnCurrentpair GetCurrentPair();
    }
}