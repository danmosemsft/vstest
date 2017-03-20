﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.VisualStudio.TestPlatform.CoreUtilities.Helpers
{
    using System.Collections.Generic;

    /// <summary>
    /// Helper class for processing arguments passed to a process.
    /// </summary>
    public class CommandLineArgumentsHelper
    {
        /// <summary>
        /// Parse command line arguments to a dictionary.
        /// </summary>
        /// <param name="args">Command line arguments. Ex: <c>{ "--port", "12312", "--parentprocessid", "2312", "--testsourcepath", "C:\temp\1.dll" }</c></param>
        /// <returns>Dictionary of arguments keys and values.</returns>
        public static IDictionary<string, string> GetArgumentsDictionary(string[] args)
        {
            var argsDictionary = new Dictionary<string, string>();
            if (args == null)
            {
                return argsDictionary;
            }

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("-"))
                {
                    if (i < args.Length - 1 && !args[i + 1].StartsWith("-"))
                    {
                        argsDictionary.Add(args[i], args[i + 1]);
                        i++;
                    }
                    else
                    {
                        argsDictionary.Add(args[i], null);
                    }
                }
            }

            return argsDictionary;
        }
    }
}