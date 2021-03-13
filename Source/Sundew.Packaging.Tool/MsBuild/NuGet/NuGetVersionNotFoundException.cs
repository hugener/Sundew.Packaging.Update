﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NuGetVersionNotFoundException.cs" company="Hukano">
// Copyright (c) Hukano. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Packaging.Tool.MsBuild.NuGet
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using global::NuGet.Versioning;
    using Sundew.Base.Collections;

    internal class NuGetVersionNotFoundException : Exception
    {
        public NuGetVersionNotFoundException(string packageId, string versionPattern, bool allowPrerelease, IReadOnlyList<NuGetVersion> versions)
            : base(FormattableString.Invariant($"{packageId}: the version pattern: {versionPattern} could not be matched ({(allowPrerelease ? "prerelease allowed" : "no prereleases")}) any of the versions:{GetVersions(versions)}"))
        {
        }

        private static string GetVersions(IReadOnlyList<NuGetVersion> versions)
        {
            return versions.AggregateToStringBuilder(new StringBuilder().AppendLine(), (builder, version) => builder.AppendLine(version.ToFullString())).ToString();
        }
    }
}