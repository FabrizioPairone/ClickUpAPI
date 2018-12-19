using Newtonsoft.Json;

namespace PaironsTech.ClickUpAPI.V1.Responses.Model
{

    /// <summary>
    /// Model object of Features information response
    /// </summary>
    public class ModelFeatures : Model
    {

        /// <summary>
        /// Model Due Dates that contains the information of this Features object
        /// </summary>
        [JsonProperty("due_dates")]
        public ModelDueDates DueDates { get; set; }

        /// <summary>
        /// Model Time Tracking that contains the information of this Features object
        /// </summary>
        [JsonProperty("time_tracking")]
        public ModelTimeTracking TimeTracking { get; set; }

        /// <summary>
        /// Model Priorities that contains the information of this Features object
        /// </summary>
        [JsonProperty("priorities")]
        public ModelPriorities Priorities { get; set; }

        /// <summary>
        /// Model Tags that contains the information of this Features object
        /// </summary>
        [JsonProperty("tags")]
        public ModelTag Tags { get; set; }

        /// <summary>
        /// Model Time Estimates that contains the information of this Features object
        /// </summary>
        [JsonProperty("time_estimates")]
        public ModelTimeEstimates TimeEstimates { get; set; }

        /// <summary>
        /// Model Custom Fields that contains the information of this Features object
        /// </summary>
        [JsonProperty("custom_fields")]
        public ModelCustomFields CustomFields { get; set; }

        /// <summary>
        /// Model Dependency Warning that contains the information of this Features object
        /// </summary>
        [JsonProperty("dependency_warning")]
        public ModelDependencyWarning DependencyWarning { get; set; }

        /// <summary>
        /// Model Multiple Assignees that contains the information of this Features object
        /// </summary>
        [JsonProperty("multiple_assignees")]
        public ModelMultipleAssignees MultipleAssignees { get; set; }

    }

}
