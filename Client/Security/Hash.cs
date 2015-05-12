// This file is part of Mystery Dungeon eXtended.

// Copyright (C) 2015 Pikablu, MDX Contributors, PMU Staff

// Mystery Dungeon eXtended is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// Mystery Dungeon eXtended is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with Mystery Dungeon eXtended.  If not, see <http://www.gnu.org/licenses/>.


namespace Client.Logic.Security
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Class that creates MD5 hashes
    /// </summary>
    public class Hash
    {
        #region Methods

        /// <summary>
        /// Generates a MD5 hash based on the source text.
        /// </summary>
        /// <param name="SourceText">The text to hash.</param>
        /// <returns>The hashed text as a Base64 string.</returns>
        public static string GenerateMD5Hash(string SourceText) {
            SourceText = SourceText + "SALT";
            //Create a salted hash so its harder to use hashtables on it
            //Create an encoding object to ensure the encoding standard for the source text
            UnicodeEncoding Ue = new UnicodeEncoding();
            //Retrieve a byte array based on the source text
            byte[] ByteSourceText = Ue.GetBytes(SourceText);
            //Instantiate an MD5 Provider object
            MD5CryptoServiceProvider Md5 = new MD5CryptoServiceProvider();
            //Compute the hash value from the source
            byte[] ByteHash = Md5.ComputeHash(ByteSourceText);
            //And convert it to String format for return
            return Convert.ToBase64String(ByteHash);
        }

        public static string GenerateSHA1Hash(string SourceText) {
            SourceText = SourceText + "SALT";
            //Create a salted hash so its harder to use hashtables on it
            //Create an encoding object to ensure the encoding standard for the source text
            UnicodeEncoding Ue = new UnicodeEncoding();
            //Retrieve a byte array based on the source text
            byte[] ByteSourceText = Ue.GetBytes(SourceText);
            //Instantiate an MD5 Provider object
            SHA1CryptoServiceProvider SHA1 = new SHA1CryptoServiceProvider();
            //Compute the hash value from the source
            byte[] ByteHash = SHA1.ComputeHash(ByteSourceText);
            //And convert it to String format for return
            return Convert.ToBase64String(ByteHash);
        }

        #endregion Methods
    }
}