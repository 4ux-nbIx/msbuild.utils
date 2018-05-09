﻿namespace MsBuild.Utils
{
    #region Namespace Imports

    using System;
    using System.Collections.Generic;

    using JetBrains.Annotations;

    using Microsoft.Build.Evaluation;

    #endregion


    internal static class ProjectExtensions
    {
        private const string _projectReferenceItemType = "ProjectReference";

        public static Guid GetProjectGuid([NotNull] this Microsoft.Build.Evaluation.Project project)
        {
            var property = project.GetProperty("ProjectGuid");

            var guid = Guid.Parse(property.EvaluatedValue);
            return guid;
        }

        public static ICollection<ProjectItem> GetProjectReferences([NotNull] this Microsoft.Build.Evaluation.Project project) =>
            project.GetItemsIgnoringCondition(_projectReferenceItemType);
    }
}