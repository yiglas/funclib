namespace funcx
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Helper class to better work with <see cref="Regex"/>. 
    /// </summary>
    public class ReMatcher
    {
        Regex _regex;
        Match _match;
        string _s;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReMatcher"/> class.
        /// </summary>
        /// <param name="regex">The <see cref="Regex"/> object.</param>
        /// <param name="s">The <see cref="string"/> using to match.</param>
        public ReMatcher(Regex regex, string s)
        {
            this._regex = regex;
            this._s = s;
            this._match = null;
        }

        /// <summary>
        /// Gets the flag indicating if the regex is been unrealized.
        /// </summary>
        public bool IsUnrealized => this._regex != null;

        /// <summary>
        /// Gets the flag indicating if the regex or match are in a failed state.
        /// </summary>
        public bool IsFailed => this._regex == null && this._match == null;

        /// <summary>
        /// Gets a flag indicating if the <see cref="ReMatcher"/> is in a Unrealized or Failed state. 
        /// </summary>
        public bool IsUnrealizedOrFailed => this._regex != null && this._match == null;

        /// <summary>
        /// Find the next match.
        /// </summary>
        /// <returns>
        /// true if another match has been found, otherwise false.
        /// </returns>
        public bool Find()
        {
            Match nextMatch;

            if (this._match != null)
                nextMatch = this._match.NextMatch();
            else if (_regex != null)
            {
                nextMatch = this._regex.Match(this._s);
                this._regex = null;
                this._s = null;
            }
            else
                return false;

            if (nextMatch.Success)
            {
                this._match = nextMatch;
                return true;
            }
            else
            {
                this._match = null;
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Matches()
        {
            if (this._regex == null)
                return false;

            string pattern = this._regex.ToString();
            bool needFront = pattern.Length == 0 || pattern[0] != '^';
            bool needRear = pattern.Length == 0 || pattern[pattern.Length - 1] != '$';

            if (needFront || needRear)
            {
                pattern = (needFront ? "^" : string.Empty) + pattern + (needRear ? "$" : string.Empty);
                this._regex = new Regex(pattern);
            }

            return Find();
        }

        /// <summary>
        /// Get the number of groups found.
        /// </summary>
        /// <returns>
        /// Returns a <see cref="int"/> representing the number of groups found.
        /// </returns>
        public int GroupCount()
        {
            if (this._match == null)
                throw new InvalidOperationException("Attempt to call GroupCount on a non-realized or failed match.");

            return this._match.Groups.Count - 1;
        }

        /// <summary>
        /// Return the captured substring from the input string.
        /// </summary>
        /// <returns></returns>
        public string Group()
        {
            if (this._match == null)
                throw new InvalidOperationException("Attempt to call group on a non-realized or failed match.");

            return this._match.Value;

        }

        /// <summary>
        /// Enables access to a member of the collection by integer index.
        /// </summary>
        /// <param name="groupIndex">The zero-based index of the collection member to be retrieved.</param>
        /// <returns>
        /// The member of the collection specified by <paramref name="groupIndex"/>.
        /// </returns>
        public string Group(int groupIndex)
        {
            if (this._match == null)
                throw new InvalidOperationException("Attempt to call group on a non-realized or failed match.");

            if (groupIndex < 0 || groupIndex >= this._match.Groups.Count)
                throw new ArgumentOutOfRangeException("groupIndex", "Attempt to call group with an index out of bounds.");

            return this._match.Groups[groupIndex].Value;
        }

        /// <summary>
        /// Gets the position in teh original string where the first character of the captured substring is found.
        /// </summary>
        /// <returns>
        /// The zero-based starting position in the original string where the captured substring is found.
        /// </returns>
        public int Start() => this._match.Index;

        /// <summary>
        /// Gets the position in the original string where the end character of the captured substring is found.
        /// </summary>
        /// <returns>
        /// The zero-based ending position in the original string where the captured substring is found.
        /// </returns>
        public int End() => this._match.Index + this._match.Length;

        /// <summary>
        /// Gets the captured substring from the input string.
        /// </summary>
        /// <returns>
        /// The substring that is captured by the match.
        /// </returns>
        public string Value() => this._match.Value;
    }
}