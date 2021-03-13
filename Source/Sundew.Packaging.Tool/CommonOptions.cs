﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonOptions.cs" company="Hukano">
// Copyright (c) Hukano. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Packaging.Tool
{
    using System;
    using System.Text.RegularExpressions;
    using Sundew.CommandLine;

    public class CommonOptions
    {
        internal const string LocalSundewName = "Local-Sundew";
        internal const string VersionGroupName = "Version";

        public static void AddVerbose(IArgumentsBuilder argumentsBuilder, bool verbose, Action<bool> setValue)
        {
            argumentsBuilder.AddSwitch("v", "verbose", verbose, setValue, "Verbose");
        }

        public static void AddRootDirectory(IArgumentsBuilder argumentsBuilder, Func<string?> serialize, Action<string> deserialize)
        {
            argumentsBuilder.AddOptional("d", "root-directory", serialize, deserialize, "The directory to search for projects", true, defaultValueText: "Current directory");
        }
    }
}