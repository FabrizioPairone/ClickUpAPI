namespace PaironsTech.ClickUpAPI.V1.Enums
{

    /// <summary>
    /// Enum that rappresent the possible values for order by of a Task
    /// </summary>
    public enum TaskOrderBy
    {

        /// <summary>
        /// Order by Id of the Task
        /// </summary>
        Id,

        /// <summary>
        /// Order by Date Creation of the task
        /// </summary>
        Created,

        /// <summary>
        /// Order by Date Last Update of the task
        /// </summary>
        Updated,

        /// <summary>
        /// Order by Due Date of the task
        /// </summary>
        DueDate
    }

}
